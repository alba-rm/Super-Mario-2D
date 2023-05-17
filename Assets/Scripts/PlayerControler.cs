using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 5.5f;
    public float jumpForce = 9f;
    string texto = "Hello World";
    

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    //examen
    public Animator anim;

    float horizontal;

    GameManager gameManager;

    //examen
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    
    public Transform attackHitBox;
    public float attackRange;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        //examen
        anim = GetComponent<Animator>();

        playerHealth = 10;
        Debug.Log(texto);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver == false)
        {

          horizontal = Input.GetAxis("Horizontal");

          //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;
        //examen
        if(horizontal < 0)
        {
            //spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("IsRunning", true);
        }
        
        else if(horizontal > 0)
        {
            //spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
        //examen no hace falta lo de gameManager = if(Input.GetKeyDown(KeyCode.F))
        if(Input.GetKeyDown(KeyCode.F) && gameManager.canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
        }
    }
    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }

    void Attack()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayer);

        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            Destroy(enemiesInRange[i].gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PowerUp")
        {
            gameManager.canShoot = true;
            Destroy(collider.gameObject);
        }
    }

    void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);
    }






        
}

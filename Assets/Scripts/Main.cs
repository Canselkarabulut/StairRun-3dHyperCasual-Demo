using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //StartPanel
    [Header("StartPanel")]
    [SerializeField] GameObject startPanel;
    //Player
    [Header("Player")]
    [SerializeField] GameObject player;
    Rigidbody playerRb;
    CapsuleCollider playerCapsuleCollider;
    Animator playerAnimator;
    public static Animator _sAnim;
    [SerializeField] RuntimeAnimatorController _rac;
    [SerializeField] Avatar _avatar;
    //Ground
    [Header("Ground")]
    [SerializeField] GameObject ground;
    //Finish
    [Header("Finish")]
    [SerializeField] GameObject finish;
    //StartOptions
    [Header("Start Options")]
    [SerializeField] GameObject infoPanel;
    public static GameObject _static›nfoPanel;
    //BagSpawn
    [Header("BagSpawn")]
    [SerializeField] GameObject spawnBagStair;
    [SerializeField] GameObject spawnStair;
    [SerializeField] GameObject inSpawn;
    public static GameObject _sSpawnBagStair;
    public static GameObject _sSpawnStair;
    public static GameObject _sInSpawn;
    public static GameObject _staticDestroyPath;
    //Die Panel
    [Header("DiePanel")]
    [SerializeField] public static GameObject _staticDiePanel;
    [SerializeField] GameObject DiePanel;
    [SerializeField] int _presentLevel;
    //NextLevelPanel
    [Header("Next Level")]   
    [SerializeField] public static GameObject _staticNextPanel;
    [SerializeField] GameObject nextPanel;
    [SerializeField] int _nextLevel;
    [SerializeField] Text pointTxt;
    public static int point;
    private void Awake()
    {
        GroundAddCompanent();
        PlayerAddCompanent();
        FinishAddCompanent();
    }
    void Start()
    {
        Assign();
        StartPanelCont();
    }
    private void FixedUpdate()
    {
        Points();
    }
    // -------------------------------------------------------------------------
    //player
    public void PlayerAddCompanent()
    {
        player.AddComponent<Rigidbody>();
        player.AddComponent<CapsuleCollider>();
        player.AddComponent<Animator>();
        playerRb = player.GetComponent<Rigidbody>();
        playerCapsuleCollider = player.GetComponent<CapsuleCollider>();
        playerAnimator = player.GetComponent<Animator>();

        //Player - RigidBody 
        playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        //Player - CapsuleCollider
        playerCapsuleCollider.center = new Vector3(0, 1.56046f, -0.1016229f);
        playerCapsuleCollider.radius = 0.6016229f;
        playerCapsuleCollider.height = 3.115255f;
        //Animator
        playerAnimator.runtimeAnimatorController = _rac;
        playerAnimator.avatar = _avatar;
        playerAnimator.applyRootMotion = true;
        playerAnimator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
    }
    //Ground
    public void GroundAddCompanent()
    {
        ground.AddComponent<BoxCollider>();
    }
    //Finish
    public void FinishAddCompanent()
    {
        finish.AddComponent<BoxCollider>();
    }
    //////-------------------------------------------------------------------------------------------------

    ///CanvasStartPanel
    public void StartPanelCont()
    {
        //StartPanel
        playerAnimator.Play("›dlePlayerAnim");
        PlayerController._staticSpeed = 0;
        //Start
        startPanel.SetActive(true);
        _static›nfoPanel.SetActive(false);
        _staticDiePanel.SetActive(false);
        _staticNextPanel.SetActive(false);
    }
    //AllAssing
    public void Assign()
    {
        _sSpawnBagStair = spawnBagStair;
        _sSpawnStair = spawnStair;
        _sAnim = playerAnimator;
        _sInSpawn = inSpawn;
        _static›nfoPanel = infoPanel;
        _staticDiePanel = DiePanel;
        _staticNextPanel = nextPanel;
    }
    public void StartBtn()
    {
        startPanel.SetActive(false);
        playerAnimator.Play("RunAnim");
        player.AddComponent<PlayerController>();
        
    }
    public void InfoButton()
    {
        _static›nfoPanel.SetActive(false);
        PlayerController._staticSpeed = 5;
        playerAnimator.Play("RunAnim");
    }
    public void TryAgainButton()
    {
        PlayerController.stair = false;
        SceneManager.LoadScene(_presentLevel);
        PlayerController.bagStair = 0;
    }
    public void NextButton()
    {
        PlayerController.stair = false;
        SceneManager.LoadScene(_nextLevel);
        PlayerController._sCamera = false;
    }
    public void Points()
    {
        if (PlayerController._sNextLevelOpen)
        {
            point = PlayerController.bagStair * 10;
            pointTxt.text = "+Points: " + point.ToString();
        }
    }
    public void Level1()
    {
        SceneManager.LoadScene(0);
    }
    public void Level2()
    {
        SceneManager.LoadScene(1);
    }
}

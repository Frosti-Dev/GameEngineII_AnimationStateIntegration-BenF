using Unity.VisualScripting;
using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    //Get all managers
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private InteractionManager interactionManager;

    //Make all managers accessible from the ServiceHub
    public GameManager GameManager => gameManager;
    public GameStateManager GameStateManager => gameStateManager;
    public LevelManager LevelManager => levelManager;
    public UiManager UIManager => uiManager;
    public InteractionManager InteractionManager => interactionManager;

    private void Awake()
    {
        if (gameManager != null) Debug.Log("GameManager is initialized!");
        if (gameStateManager != null) Debug.Log("GameStateManager is initialized!");
        if (levelManager != null) Debug.Log("LevelManager is initialized!");
        if (uiManager != null) Debug.Log("UiManager is initialized!");
        if(interactionManager != null) Debug.Log("InteractionManager is initialized!");

        Instance = this;
    }
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

}

using UnityEngine;

public class IdleGameState : MonoBehaviour
{
    public static IdleGameState Instance { get; private set; }

    [Header("Основные значения")]
    [SerializeField] private double hearts = 0;           // текущие сердца
    [SerializeField] private double heartsPerClick = 1;   // сколько даёт один клик
    [SerializeField] private double heartsPerSecond = 0;  // пассивный доход в секунду

    [Header("Премиум-валюта")]
    [SerializeField] private double diamonds = 0;         // бриллианты (донат)

    // Свойства
    public double Hearts
    {
        get => hearts;
        set => hearts = value;
    }

    public double HeartsPerClick
    {
        get => heartsPerClick;
        set => heartsPerClick = value;
    }

    public double HeartsPerSecond
    {
        get => heartsPerSecond;
        set => heartsPerSecond = value;
    }

    public double Diamonds
    {
        get => diamonds;
        set => diamonds = value;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (heartsPerSecond > 0)
        {
            hearts += heartsPerSecond * Time.deltaTime;
        }
    }

    // --- Сердца ---

    public void AddHearts(double amount)
    {
        hearts += amount;
    }

    public bool SpendHearts(double amount)
    {
        if (hearts < amount)
            return false;

        hearts -= amount;
        return true;
    }

    public void AddHeartsPerClick(double amount)
    {
        heartsPerClick += amount;
    }

    public void AddHeartsPerSecond(double amount)
    {
        heartsPerSecond += amount;
    }

    // --- Бриллианты ---

    public void AddDiamonds(double amount)
    {
        diamonds += amount;
    }

    public bool SpendDiamonds(double amount)
    {
        if (diamonds < amount)
            return false;

        diamonds -= amount;
        return true;
    }
}

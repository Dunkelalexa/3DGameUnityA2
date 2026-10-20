using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;

    [Tooltip("Seconds the player can't be hurt again after taking damage")]
    [Header("Invulnerabilty")]
    [SerializeField] private float invulnerabilityTime = 0.5f;

    private int _currentHealth;
    private float _invulnerableTimer = 0f;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => _currentHealth;
    public bool IsDead { get; private set; }

    private void Start()
    {
        GameManager.Instance.UpdateHealthUI(_currentHealth);
    }
    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        if (_invulnerableTimer > 0f)
        {
            _invulnerableTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage( int amount)
    {
        if (IsDead) return;
        if (_invulnerableTimer > 0f) return;

        _currentHealth -= amount;
        _invulnerableTimer = invulnerabilityTime;
        Debug.Log("Player health: " + _currentHealth);

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            IsDead = true;
            GameManager.Instance.GameOver();
        }

        GameManager.Instance.UpdateHealthUI(_currentHealth);

    }

    public void Heal( int amount )
    {
        if (IsDead) return;

        _currentHealth += amount;
        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }

        GameManager.Instance.UpdateHealthUI(_currentHealth);
    }
}

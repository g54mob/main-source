using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
	public Image mainImage;

	public Image hpBar;

	public GameObject shieldBarBackground;

	public Image shieldBar;

	public TMP_Text enemyName;

	[SerializeField]
	private GameObject powerOrdealIcon;

	[SerializeField]
	private TMP_Text debugHp;

	[SerializeField]
	private Vector3 lastBossPosition;

	[SerializeField]
	private Vector3 lastBossScale;

	private float _maxHp;

	private float _maxShield;

	private BaseEnemy _enemy;

	private Vector3? _initPos;

	private Vector3? _initScale;

	private Vector3? _initAnchorMax;

	private Vector3? _initAnchorMin;

	public void InitComponent(BaseEnemy baseEnemy)
	{
	}

	public void AddShield(int shield)
	{
	}

	private void Update()
	{
	}
}

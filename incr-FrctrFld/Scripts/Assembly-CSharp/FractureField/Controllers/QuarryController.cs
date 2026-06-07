using FractureField.Rocks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.Controllers
{
	public class QuarryController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private RectTransform _quarryPanelRect;

		[SerializeField]
		private Transform _quarryBounds;

		[Header("Rocks")]
		public Transform rockContainer;

		public GameObject rockControllerPrefab;

		[Header("Bombs")]
		public GameObject bombIcon;

		public TextMeshProUGUI bombChargesText;

		public Image bombIconImage;

		public Image bombCooldownCircle;

		public GameObject bombExplosionPrefab;

		public Transform effectsContainer;

		private Vector2 _lastScreenSize;

		private int _lastCurrentCharges;

		private int _lastMaxCharges;

		private float _lastBombIconAlpha;

		private bool _lastBombIconActive;

		private float _lastCooldownFillAmount;

		private bool _lastCooldownCircleActive;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void UpdateQuarryBoundsScale()
		{
		}

		private void Setup()
		{
		}

		private void UpdateBombUI()
		{
		}

		private void OnRockAdded()
		{
		}

		private void CreateRockController(Rock rock)
		{
		}

		private void OnBombUsed()
		{
		}

		public void CreateBombExplosion(Vector3 worldPosition)
		{
		}
	}
}

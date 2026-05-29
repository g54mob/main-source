using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
	public class RouteEnemyInfo : MonoBehaviour
	{
		public RectTransform rectTf;

		[SerializeField]
		private Image title;

		[SerializeField]
		private Image mainImage;

		[SerializeField]
		private TMP_Text enemyName;

		[SerializeField]
		private TMP_Text enemyDesc;

		[SerializeField]
		private Sprite namedTitle;

		[SerializeField]
		private Sprite bossTitle;

		[SerializeField]
		private float offsetX;

		[SerializeField]
		private Vector3 tweenStartOffset;

		[SerializeField]
		private float limitY;

		[SerializeField]
		private ChoiceMenuButtonBase ordealDetail;

		[SerializeField]
		private InputActionReference _inputAction;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		private InputAction _action;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public void InitInstance(eEnemyType type, eEnemy enemy, bool isPowerOrdeal = false)
		{
		}

		public void DisplayInfo(Transform button, int? sign = null)
		{
		}
	}
}

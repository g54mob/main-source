using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class NimbatusToolTip : MonoBehaviour
	{
		protected static NimbatusToolTip MInstance;

		private Camera _uiCamera;

		public UILabel Text;

		public WeaponDetails WeaponDetails;

		public ShowWeaponPreview WeaponPreview;

		public GameObject TooltipRoot;

		public UISprite Background;

		public const float AppearSpeed = 20f;

		private GameObject _mTooltip;

		private Transform _mTrans;

		private float _mTarget;

		private float _mCurrent;

		private Vector3 _mPos;

		private Vector3 _mSize = Vector3.zero;

		private Vector2 _additionalSize = Vector2.zero;

		protected UIWidget[] MWidgets;

		public static bool IsVisible
		{
			get
			{
				if (MInstance != null)
				{
					return MInstance._mTarget >= 1f;
				}
				return false;
			}
		}

		public void Awake()
		{
			MInstance = this;
		}

		public void OnDestroy()
		{
			MInstance = null;
		}

		protected virtual void Start()
		{
			_mTrans = base.transform;
			MWidgets = GetComponentsInChildren<UIWidget>();
			_mPos = _mTrans.localPosition;
			_uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
			SetAlpha(0f);
		}

		protected virtual void Update()
		{
			if (_mTooltip != UICamera.tooltipObject)
			{
				_mTooltip = null;
				_mTarget = 0f;
			}
			if (_mCurrent != _mTarget)
			{
				_mCurrent = Mathf.Lerp(_mCurrent, _mTarget, RealTime.deltaTime * 20f);
				if (Mathf.Abs(_mCurrent - _mTarget) < 0.001f)
				{
					_mCurrent = _mTarget;
				}
				SetAlpha(_mCurrent * _mCurrent);
			}
		}

		protected virtual void SetAlpha(float val)
		{
			int i = 0;
			for (int num = MWidgets.Length; i < num; i++)
			{
				UIWidget obj = MWidgets[i];
				Color color = obj.color;
				color.a = val;
				obj.color = color;
			}
		}

		protected virtual void SetText(string tooltipText)
		{
			if (Text != null && !string.IsNullOrEmpty(tooltipText))
			{
				_mTarget = 1f;
				_mTooltip = UICamera.tooltipObject;
				Text.text = tooltipText;
				_mPos = UICamera.lastEventPosition;
				Transform obj = Text.transform;
				Vector3 localPosition = obj.localPosition;
				Vector3 localScale = obj.localScale;
				_mSize = Text.printedSize + _additionalSize;
				_mSize.x *= localScale.x;
				_mSize.y *= localScale.y;
				if (Background != null)
				{
					Vector4 border = Background.border;
					_mSize.x += border.x + border.z + (localPosition.x - border.x) * 2f;
					_mSize.y += border.y + border.w + (0f - localPosition.y - border.y) * 2f;
					Background.width = Mathf.RoundToInt(_mSize.x);
					Background.height = Mathf.RoundToInt(_mSize.y);
				}
				if (_uiCamera != null)
				{
					_mPos.x = Mathf.Clamp01(_mPos.x / (float)Screen.width);
					_mPos.y = Mathf.Clamp01(_mPos.y / (float)Screen.height);
					float num = _uiCamera.orthographicSize / _mTrans.parent.lossyScale.y;
					float num2 = (float)Screen.height * 0.5f / num;
					Vector2 vector = new Vector2(num2 * _mSize.x / (float)Screen.width, num2 * _mSize.y / (float)Screen.height);
					_mPos.x = Mathf.Min(_mPos.x, 1f - vector.x);
					_mPos.y = Mathf.Max(_mPos.y, vector.y);
					_mTrans.position = _uiCamera.ViewportToWorldPoint(_mPos);
					_mPos = _mTrans.localPosition;
					_mPos.x = Mathf.Round(_mPos.x);
					_mPos.y = Mathf.Round(_mPos.y);
				}
				else
				{
					if (_mPos.x + _mSize.x > (float)Screen.width)
					{
						_mPos.x = (float)Screen.width - _mSize.x;
					}
					if (_mPos.y - _mSize.y < 0f)
					{
						_mPos.y = _mSize.y;
					}
					_mPos.x -= (float)Screen.width * 0.5f;
					_mPos.y -= (float)Screen.height * 0.5f;
				}
				_mTrans.localPosition = _mPos;
				if (TooltipRoot != null)
				{
					TooltipRoot.BroadcastMessage("UpdateAnchors");
				}
				else
				{
					Text.BroadcastMessage("UpdateAnchors");
				}
			}
			else
			{
				_mTooltip = null;
				_mTarget = 0f;
			}
		}

		public static void Show(string text, bool show = true)
		{
			if (!show || string.IsNullOrEmpty(text))
			{
				Hide();
			}
			else if (MInstance != null)
			{
				MInstance._additionalSize = Vector2.zero;
				MInstance.WeaponDetails.gameObject.SetActive(false);
				MInstance.WeaponPreview.gameObject.SetActive(false);
				MInstance.SetText(text);
			}
		}

		private static void Hide()
		{
			if (MInstance != null)
			{
				MInstance._mTooltip = null;
				MInstance._mTarget = 0f;
				MInstance.WeaponDetails.gameObject.SetActive(false);
				MInstance.WeaponPreview.gameObject.SetActive(false);
			}
		}

		public static void ShowWeapon(Weapon weapon, bool showPreview, bool show = true)
		{
			if (!show)
			{
				Hide();
			}
			else if (MInstance != null)
			{
				MInstance.InitWeaponDetails(weapon, showPreview);
				MInstance.UpdateSize(weapon.UpgradeSlots, showPreview);
				MInstance.SetText(weapon.GetTooltip());
			}
		}

		public static void ShowWeapon(WeaponPreset weapon, bool showPreview, bool show = true)
		{
			if (!show)
			{
				Hide();
			}
			else if (MInstance != null)
			{
				MInstance.InitWeaponDetails(weapon, showPreview);
				MInstance.UpdateSize(weapon.UpgradeSlots, showPreview);
				MInstance.SetText(weapon.GetTooltip());
			}
		}

		private void InitWeaponDetails(Weapon weapon, bool showPreview)
		{
			WeaponDetails.gameObject.SetActive(true);
			WeaponDetails.ShowWeapon(weapon, false);
			if (showPreview)
			{
				WeaponPreview.gameObject.SetActive(true);
				WeaponPreview.ShowWeapon(weapon);
			}
			else
			{
				WeaponPreview.gameObject.SetActive(false);
			}
		}

		private void InitWeaponDetails(WeaponPreset weapon, bool showPreview)
		{
			WeaponDetails.gameObject.SetActive(true);
			WeaponDetails.ShowWeaponPreset(weapon);
			if (showPreview)
			{
				WeaponPreview.gameObject.SetActive(true);
				WeaponPreview.ShowWeaponPreset(weapon);
			}
			else
			{
				WeaponPreview.gameObject.SetActive(false);
			}
		}

		private void UpdateSize(int upgradeSlots, bool showPreview)
		{
			if (upgradeSlots > 0)
			{
				_additionalSize = new Vector2(0f, showPreview ? 310 : 160);
				WeaponPreview.gameObject.transform.localPosition = new Vector3(WeaponPreview.transform.localPosition.x, -350f, WeaponPreview.transform.localPosition.z);
			}
			else
			{
				_additionalSize = new Vector2(0f, showPreview ? 230 : 100);
				WeaponPreview.gameObject.transform.localPosition = new Vector3(WeaponPreview.transform.localPosition.x, -275f, WeaponPreview.transform.localPosition.z);
			}
		}
	}
}

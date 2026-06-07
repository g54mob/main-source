using CurvedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public class TargetBoxScriptXR : TargetBoxScript
	{
		private Canvas _canvas;

		private CurvedUISettings _curvedUI;

		[SerializeField]
		private TextMeshProUGUI _distanceLabel;

		[SerializeField]
		private TextMeshProUGUI _nameLabel;

		private Image _sprite;

		protected override Color DistanceLabelColor
		{
			get
			{
				return _distanceLabel.color;
			}
			set
			{
				_distanceLabel.color = value;
			}
		}

		protected override GameObject DistanceLabelObject => _distanceLabel.gameObject;

		protected override string DistanceLabelText
		{
			get
			{
				return _distanceLabel.text;
			}
			set
			{
				_distanceLabel.text = value;
			}
		}

		protected override Color NameLabelColor
		{
			get
			{
				return _nameLabel.color;
			}
			set
			{
				_nameLabel.color = value;
			}
		}

		protected override GameObject NameLabelObject => _nameLabel.gameObject;

		protected override string NameLabelText
		{
			get
			{
				return _nameLabel.text;
			}
			set
			{
				_nameLabel.text = value;
			}
		}

		protected override Color SpriteColor
		{
			get
			{
				return _sprite.color;
			}
			set
			{
				_sprite.color = value;
			}
		}

		protected override bool SpriteEnabled
		{
			get
			{
				return _sprite.enabled;
			}
			set
			{
				_sprite.enabled = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_curvedUI = GetComponentInParent<CurvedUISettings>();
			_canvas = GetComponentInParent<Canvas>();
			_sprite = GetComponent<Image>();
			CurvedUIVertexEffect[] componentsInChildren = GetComponentsInChildren<CurvedUIVertexEffect>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}

		protected override Vector3 GetScreenPos()
		{
			Vector3 position = _mainCamera.transform.position;
			_curvedUI.RaycastToCanvasSpace(new Ray(position, (base.TrackedTarget.Target.Position - position).normalized), out var o_positionOnCanvas);
			return o_positionOnCanvas;
		}

		protected override Vector3 GetWorldPoint(Vector3 screenPos)
		{
			return _curvedUI.CanvasToCurvedCanvas(screenPos);
		}

		protected override bool IsVisible(Vector3 screenPos)
		{
			return true;
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			base.transform.rotation = Quaternion.LookRotation(base.TrackedTarget.Target.Position - _mainCamera.transform.position);
		}

		protected override void SetOrder(int order)
		{
			_canvas.sortingOrder = order;
		}

		protected override void Start()
		{
			base.Start();
			_canvas.overrideSorting = true;
		}
	}
}

using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemVisualEditAnimator : MonoBehaviour
	{
		private bool _visible;

		private float _alpha;

		private Color _innerColor;

		private Color _outlineColor;

		private Color _wantedInnerColor;

		private Color _wantedOutlineColor;

		private MeshRenderer _meshRenderer;

		private List<GameObject> _interactionPoints;

		private MaterialPropertyBlock _materialPropertyBlockInner;

		private MaterialPropertyBlock _materialPropertyBlockOutline;

		public void Initialise(MeshRenderer meshRenderer, List<GameObject> interactionPoints)
		{
			_wantedInnerColor = Color.clear;
			_wantedOutlineColor = Color.clear;
			_meshRenderer = meshRenderer;
			_interactionPoints = interactionPoints;
			_materialPropertyBlockInner = new MaterialPropertyBlock();
			_materialPropertyBlockOutline = new MaterialPropertyBlock();
		}

		public void SetVisible(bool visible)
		{
			_visible = visible;
		}

		public void SetColors(Color color1, Color color2)
		{
			_wantedInnerColor = color1;
			_wantedOutlineColor = color2;
		}

		private void LateUpdate()
		{
			float num = _alpha * _alpha;
			float t = Time.unscaledDeltaTime * 2f;
			float num2 = Time.unscaledDeltaTime * 8f;
			_innerColor = Color.Lerp(_innerColor, _wantedInnerColor, t);
			_outlineColor = Color.Lerp(_outlineColor, _wantedOutlineColor, t);
			_materialPropertyBlockInner.SetColor("_Color", new Color(_innerColor.r, _innerColor.g, _innerColor.b, _innerColor.a * num));
			_materialPropertyBlockOutline.SetColor("_Color", new Color(_outlineColor.r, _outlineColor.g, _outlineColor.b, _outlineColor.a * num));
			_meshRenderer.SetPropertyBlock(_materialPropertyBlockInner, 0);
			_meshRenderer.SetPropertyBlock(_materialPropertyBlockOutline, 1);
			foreach (GameObject interactionPoint in _interactionPoints)
			{
				interactionPoint.transform.localScale = new Vector3(num, 1f, num);
			}
			if (_visible)
			{
				_alpha = Mathf.Clamp01(_alpha + num2);
				return;
			}
			_alpha = Mathf.Clamp01(_alpha - num2 * 2f);
			if (_alpha <= 0f)
			{
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
			}
		}
	}
}

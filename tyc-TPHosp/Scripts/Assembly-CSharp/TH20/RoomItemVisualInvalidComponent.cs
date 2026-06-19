using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemVisualInvalidComponent : MonoBehaviour
	{
		private bool _valid;

		private float _alpha;

		private float _lastAlpha;

		private float _alphaMultiplier = 1f;

		private RoomItemVisual _roomItemVisual;

		private RoomItemVisualEdit.Config _roomItemEditConfig;

		public void Initialise(RoomItemVisual roomItemVisual, RoomItemVisualEdit.Config roomItemEditConfig)
		{
			_roomItemVisual = roomItemVisual;
			_roomItemEditConfig = roomItemEditConfig;
		}

		public void Reset()
		{
			_alphaMultiplier = 0f;
		}

		public void SetValid(bool visible)
		{
			_valid = visible;
		}

		private void OnDestroy()
		{
			_roomItemVisual.SetEditAlpha(1f);
		}

		private void LateUpdate()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			if (_valid)
			{
				_alpha = Mathf.Clamp01(_alpha + unscaledDeltaTime * _roomItemEditConfig.ValidFadeInSpeed);
			}
			else
			{
				_alpha = Mathf.Clamp01(_alpha - unscaledDeltaTime * _roomItemEditConfig.InvalidFadeInSpeed);
			}
			_alphaMultiplier = Mathf.Min(_alphaMultiplier + unscaledDeltaTime * _roomItemEditConfig.InitialFadeInSpeed, 1f);
			float num = Mathf.Lerp(_roomItemEditConfig.InvalidAlpha, 1f, _alpha * _alpha) * _alphaMultiplier;
			if (Mathf.Abs(num - _lastAlpha) > 0f)
			{
				_lastAlpha = num;
				_roomItemVisual.SetEditAlpha(num);
			}
		}
	}
}

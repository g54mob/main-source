using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Vertex Curve Animation", menuName = "Text Animator/Animations/Special/Vertex Curve Animation")]
	[EffectInfo(null, EffectCategory.All)]
	public sealed class VertexCurveAnimation : AnimationScriptableBase
	{
		public TimeMode timeMode;

		[EmissionCurveProperty]
		public EmissionCurve emissionCurve;

		[SerializeField]
		private AnimationData[] animationPerVertexData;

		private float timeSpeed;

		private float weightMult;

		private Matrix4x4 matrix;

		private Vector3 offset;

		private Vector3 movement;

		private Vector2 scale;

		private Quaternion rot;

		private Color32 color;

		private float timePassed;

		public AnimationData[] VertexData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}

		public override float GetMaxDuration()
		{
			return 0f;
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return false;
		}

		private void ClampVertexDataArray()
		{
		}

		private void OnValidate()
		{
		}
	}
}

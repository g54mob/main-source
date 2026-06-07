using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Vertex Curve Animation", menuName = "Text Animator/Animations/Special/Vertex Curve Animation")]
	[EffectInfo("", EffectCategory.All)]
	public sealed class VertexCurveAnimation : AnimationScriptableBase
	{
		public TimeMode timeMode = new TimeMode(useUniformTime: true);

		[EmissionCurveProperty]
		public EmissionCurve emissionCurve = new EmissionCurve();

		[SerializeField]
		private AnimationData[] animationPerVertexData = new AnimationData[4];

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
				return animationPerVertexData;
			}
			set
			{
				animationPerVertexData = value;
				ClampVertexDataArray();
			}
		}

		public override void ResetContext(TAnimCore animator)
		{
			weightMult = 1f;
			timeSpeed = 1f;
			ClampVertexDataArray();
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			string text = modifier.name;
			if (!(text == "f"))
			{
				if (text == "a")
				{
					weightMult = modifier.value;
				}
			}
			else
			{
				timeSpeed = modifier.value;
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			timePassed = timeMode.GetTime(animator.time.timeSinceStart * timeSpeed, character.passedTime * timeSpeed, character.index);
			if (timePassed < 0f)
			{
				return;
			}
			float num = weightMult * emissionCurve.Evaluate(timePassed);
			for (byte b = 0; b < 4; b++)
			{
				if (animationPerVertexData[b].TryCalculatingMatrix(character, timePassed, num, out matrix, out offset))
				{
					character.current.positions[b] = matrix.MultiplyPoint3x4(character.current.positions[b] - offset) + offset;
				}
				if (animationPerVertexData[b].TryCalculatingColor(character, timePassed, num, out color))
				{
					character.current.colors[b] = Color32.LerpUnclamped(character.current.colors[b], color, Mathf.Clamp01(num));
				}
			}
		}

		public override float GetMaxDuration()
		{
			return emissionCurve.GetMaxDuration();
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return true;
		}

		private void ClampVertexDataArray()
		{
			for (int i = 0; i < animationPerVertexData.Length; i++)
			{
				if (animationPerVertexData[i] == null)
				{
					animationPerVertexData[i] = new AnimationData();
				}
			}
			if (animationPerVertexData.Length == 4)
			{
				return;
			}
			Debug.LogError("Vertex data array must have four vertices. Clamping/Resizing to four.");
			AnimationData[] array = new AnimationData[4];
			for (int j = 0; j < array.Length; j++)
			{
				if (j < animationPerVertexData.Length)
				{
					array[j] = animationPerVertexData[j];
				}
				else
				{
					array[j] = new AnimationData();
				}
			}
			animationPerVertexData = array;
		}

		private void OnValidate()
		{
			ClampVertexDataArray();
		}
	}
}

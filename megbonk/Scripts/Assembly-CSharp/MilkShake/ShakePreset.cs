using UnityEngine;

namespace MilkShake
{
	[CreateAssetMenu(fileName = "New Shake Preset", menuName = "MilkShake/Shake Preset")]
	public class ShakePreset : ScriptableObject, IShakeParameters
	{
		[Header("Shake Type")]
		[SerializeField]
		private ShakeType shakeType;

		[Header("Shake Strength")]
		[SerializeField]
		private float strength;

		[SerializeField]
		private float roughness;

		[Header("Fade")]
		[SerializeField]
		private float fadeIn;

		[SerializeField]
		private float fadeOut;

		[Header("Shake Influence")]
		[SerializeField]
		private Vector3 positionInfluence;

		[SerializeField]
		private Vector3 rotationInfluence;

		public ShakeType ShakeType
		{
			get
			{
				return default(ShakeType);
			}
			set
			{
			}
		}

		public float Strength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Roughness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FadeIn
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FadeOut
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 PositionInfluence
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 RotationInfluence
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}
	}
}

using UnityEngine;

namespace MagicaCloth2
{
	[AddComponentMenu("MagicaCloth2/MagicaWindZone")]
	[HelpURL("https://magicasoft.jp/en/mc2_windzone_component/")]
	public class MagicaWindZone : ClothBehaviour
	{
		public enum Mode
		{
			GlobalDirection = 0,
			SphereDirection = 1,
			BoxDirection = 2,
			SphereRadial = 10
		}

		public Mode mode;

		public Vector3 size;

		public float radius;

		[Range(0f, 30f)]
		public float main;

		[Range(0f, 1f)]
		public float turbulence;

		[Range(-180f, 180f)]
		public float directionAngleX;

		[Range(-180f, 180f)]
		public float directionAngleY;

		public AnimationCurve attenuation;

		public bool isAddition;

		public int WindId { get; private set; }

		protected void Awake()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected void OnDestroy()
		{
		}

		public bool IsDirection()
		{
			return false;
		}

		public bool IsRadial()
		{
			return false;
		}

		public bool IsAddition()
		{
			return false;
		}

		public Vector3 GetWindDirection(bool localSpace = false)
		{
			return default(Vector3);
		}

		public void SetWindDirection(Vector3 dir, bool localSpace = false)
		{
		}
	}
}

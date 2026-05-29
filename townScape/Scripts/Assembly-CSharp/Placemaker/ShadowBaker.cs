using System;
using UnityEngine;

namespace Placemaker
{
	public class ShadowBaker : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private RenderTexture tex0;

		[SerializeField]
		private Texture noiseTex;

		[SerializeField]
		private Camera cam;

		[SerializeField]
		private Transform shadowPlane;

		private int resolution;

		public static readonly int worldToShadowId;

		public static readonly int shadowToWorldId;

		public static readonly int shadowRangeId;

		public static readonly int sunDirId;

		public static readonly int sunColorId;

		public static readonly int shadowColorId;

		public static readonly int bgColorId;

		public static readonly int lampId;

		public int count;

		public Vector2 current;

		public Vector2 target;

		[SerializeField]
		private Gradient sunColor;

		[SerializeField]
		private Gradient shadowColor;

		[SerializeField]
		private Gradient bgColor;

		[SerializeField]
		private Texture2D lampTex;

		private const int windowSizeX = 32;

		private const int windowSizeY = 32;

		private bool framingDirty;

		private bool angleDirty;

		private bool snap;

		private bool shouldBake;

		public Action onNewSunAngle;

		private float lamps;

		public void OnStart()
		{
		}

		public void MaybeUpdateFraming()
		{
		}

		public void BakeShadow()
		{
		}

		public void SetFramingDirty()
		{
		}

		public void OnBuilt()
		{
		}

		public void LateUpdate()
		{
		}

		private void UpdateLamps()
		{
		}

		private static Quaternion GetQuaternion(Vector2 value)
		{
			return default(Quaternion);
		}

		public void MaybeUpdateAngle()
		{
		}

		public void RotateAngle(Vector2 delta)
		{
		}

		public void SetAngle(Vector2 newTarget)
		{
		}

		public void SetX(float x)
		{
		}

		public void SetY(float y)
		{
		}

		public void Load(SaveData saveData)
		{
		}

		public void Save(SaveData saveData)
		{
		}
	}
}

using UnityEngine;

namespace Placemaker.Ui
{
	public class UiScaler : MonoBehaviour
	{
		[SerializeField]
		private bool skipCustomScaling;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void SetScale()
		{
		}

		public static float GetScale()
		{
			return 0f;
		}

		public static int GetDefaultAntiAliasing()
		{
			return 0;
		}
	}
}

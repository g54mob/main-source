using System.Collections.Generic;
using UnityEngine;

namespace GameKit.Utilities.Types
{
	public class RectTransformResizer : MonoBehaviour
	{
		public class ResizeData : IResettable
		{
			public byte Remaining;

			public ResizeDelegate Delegate;

			public void InitializeState()
			{
			}

			public void ResetState()
			{
			}
		}

		public delegate void ResizeDelegate(bool complete);

		private List<ResizeData> _resizeDatas;

		private static RectTransformResizer _instance;

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void Resize()
		{
		}

		public static void Resize(ResizeDelegate del)
		{
		}

		private void Resize_Internal(ResizeDelegate del)
		{
		}
	}
}

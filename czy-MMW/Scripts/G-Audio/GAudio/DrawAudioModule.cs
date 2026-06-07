using UnityEngine;
using UnityEngine.Rendering;

namespace GAudio
{
	public class DrawAudioModule : AGATChunkCopyClientBehaviour
	{
		public Color startColor;

		public Color endColor;

		public float lineWidthStart = 1f;

		public float lineWidthEnd = 1f;

		public float xFactor = 0.01f;

		public float yFactor = 5f;

		public Material lineMaterial;

		public bool handleNoMoreDataInStart;

		protected LineRenderer _lineRenderer;

		public LineRenderer Line => _lineRenderer;

		protected override void Start()
		{
			base.Start();
			_lineRenderer = base.gameObject.AddComponent<LineRenderer>();
			_lineRenderer.shadowCastingMode = ShadowCastingMode.Off;
			_lineRenderer.receiveShadows = false;
			SetVertexCount();
			_lineRenderer.startColor = startColor;
			_lineRenderer.endColor = endColor;
			_lineRenderer.startWidth = lineWidthStart;
			_lineRenderer.endWidth = lineWidthEnd;
			_lineRenderer.material = lineMaterial;
			_lineRenderer.useWorldSpace = false;
			if (handleNoMoreDataInStart)
			{
				HandleNoMoreData();
			}
		}

		protected virtual void SetVertexCount()
		{
			_lineRenderer.positionCount = _data.Length;
		}

		protected override void HandleAudioDataUpdate()
		{
			int num = _data.Length;
			for (int i = 0; i < num; i++)
			{
				_lineRenderer.SetPosition(i, new Vector3((float)i * xFactor, _data[i] * yFactor, 0f));
			}
		}

		protected override void HandleNoMoreData()
		{
			int num = _data.Length;
			for (int i = 0; i < num; i++)
			{
				_lineRenderer.SetPosition(i, new Vector3((float)i * xFactor, 0f, 0f));
			}
		}
	}
}

using System;
using UnityEngine;

public class TrainBufferController : BufferControllerBase
{
	private const string BUFFERS_PARENT = "[buffers]";

	private const string BUFFER_OBJECT_PREFIX = "Buffer_";

	private const float BUFFER_WIDTH = 0.265f;

	private const float BUFFER_RIG_X = 0f;

	private const float BUFFER_RIG_Y = 1.05f;

	private const float BUFFER_RIG_Z_MODEL_OFFSET = 0.005f;

	public CouplingScanner couplingScanner;

	public Transform bufferAnchorLeft;

	public Transform bufferAnchorRight;

	public Transform bufferModelLeft;

	public Transform bufferModelRight;

	private BufferControllerBase otherBuffers;

	private void Awake()
	{
		bufferWidth = 0.265f;
		bufferCompressionRange = bufferAnchorLeft.localPosition.z;
		sidewaysOffset = Mathf.Abs(bufferAnchorLeft.localPosition.x);
		couplingScanner.ScanStateChanged += OnScannerStateChanged;
		OnScannerStateChanged(couplingScanner.nearbyScanner);
		bufferModelLeft.SetParent(bufferAnchorLeft);
		bufferModelRight.SetParent(bufferAnchorRight);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && (bool)couplingScanner)
		{
			couplingScanner.ScanStateChanged -= OnScannerStateChanged;
		}
	}

	private void OnScannerStateChanged(CouplingScanner otherScanner)
	{
		if (otherScanner != null)
		{
			SetOtherBuffer(otherScanner.GetComponent<BufferControllerBase>());
			if (otherBuffers == null)
			{
				Debug.LogError("TrainBufferController got other CouplingScanner but couldn't find a BufferControllerBase, check prefab setup", otherScanner);
			}
		}
		else
		{
			SetOtherBuffer(null);
		}
	}

	public void SetOtherBuffer(BufferControllerBase controller)
	{
		otherBuffers = controller;
		if (otherBuffers == null)
		{
			UpdateBufferCompression();
		}
	}

	private void OnDisable()
	{
		SetOtherBuffer(null);
	}

	public void UpdateVisible()
	{
		if (!(otherBuffers == null))
		{
			UpdateBuffers();
		}
	}

	public void UpdateBuffers()
	{
		Transform transform = base.transform;
		Transform transform2 = otherBuffers.transform;
		Vector3 position = transform2.position;
		Vector3 vector = transform2.right * otherBuffers.sidewaysOffset;
		float f = (float)Math.PI / 180f * Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.y - transform2.rotation.eulerAngles.y - 180f, 0f));
		float num = Mathf.Sin(f);
		float num2 = Mathf.Cos(f);
		float num3 = num * otherBuffers.bufferWidth * 0.8f;
		float value = transform.InverseTransformPoint(position + vector).z - num3;
		float value2 = transform.InverseTransformPoint(position - vector).z - num3;
		float a = bufferCompressionRange + num2 * otherBuffers.bufferCompressionRange;
		float leftCompression = Mathf.Clamp01(Mathf.InverseLerp(a, 0f, value));
		float rightCompression = Mathf.Clamp01(Mathf.InverseLerp(a, 0f, value2));
		UpdateBufferCompression(leftCompression, rightCompression);
	}

	private void UpdateBufferCompression(float leftCompression = 0f, float rightCompression = 0f)
	{
		UpdateBufferPosition(bufferAnchorLeft, leftCompression);
		UpdateBufferPosition(bufferAnchorRight, rightCompression);
	}

	private void UpdateBufferPosition(Transform buffer, float compression)
	{
		Vector3 localPosition = buffer.transform.localPosition;
		localPosition.z = Mathf.Lerp(bufferCompressionRange, 0f, compression);
		buffer.transform.localPosition = localPosition;
	}
}

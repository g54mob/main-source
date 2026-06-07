using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CursorTrailRenderer : MonoBehaviour
{
	[SerializeField]
	private int frameDelay = 8;

	[SerializeField]
	private Image[] trailRenderers = Array.Empty<Image>();

	[SerializeField]
	private CursorSkin defaultSkin;

	private Vector3[] _positions;

	private CancellationTokenSource _cts;

	private void Awake()
	{
		InitializeTrails();
		Database.State.Customization.Cursor.Subscribe(UpdateTexture).AddTo(this);
		Database.State.Customization.TrailingCursor.Subscribe(StartTrailing, StopTrailing).AddTo(this);
	}

	private void OnDestroy()
	{
		UpdateTexture(defaultSkin);
	}

	private void InitializeTrails()
	{
		_positions = new Vector3[trailRenderers.Length];
		for (int i = 0; i < trailRenderers.Length; i++)
		{
			Color color = trailRenderers[i].color;
			color.a = 1f - ((float)i + 1f) / ((float)trailRenderers.Length + 1f);
			trailRenderers[i].color = color;
		}
	}

	private void StartTrailing()
	{
		Image[] array = trailRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: true);
		}
		TrailAsync(this.GenerateToken(ref _cts)).Forget();
	}

	private void StopTrailing()
	{
		this.CancelToken(ref _cts);
		Image[] array = trailRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
	}

	private void UpdateTexture(CursorSkin skin)
	{
		Texture2D texture = skin.Value().texture;
		Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
		Image[] array = trailRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].overrideSprite = texture.ToSprite();
		}
	}

	private async UniTaskVoid TrailAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.transform as RectTransform, Mouse.current.position.ReadValue(), UI.Registry.cameras.main, out var localPoint);
			for (int num = _positions.Length - 1; num > 0; num--)
			{
				_positions[num] = _positions[num - 1];
			}
			_positions[0] = localPoint;
			for (int i = 0; i < trailRenderers.Length; i++)
			{
				trailRenderers[i].rectTransform.anchoredPosition3D = _positions[i];
			}
			await UniTask.DelayFrame(frameDelay, PlayerLoopTiming.Update, token);
		}
	}
}

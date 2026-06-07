using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class ColorPicker : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IPointerUpHandler
{
	private enum PointerDownLocation
	{
		HueCircle = 0,
		SVSquare = 1,
		Outside = 2
	}

	private const float recip2Pi = 1f / (2f * (float)Math.PI);

	private const string colorPickerShaderName = "UI/ColorPicker";

	private static readonly int _HSV;

	private static readonly int _AspectRatio;

	private static readonly int _HueCircleInner;

	private static readonly int _SVSquareSize;

	[SerializeField]
	[HideInInspector]
	private Shader colorPickerShader;

	private Material generatedMaterial;

	private PointerDownLocation pointerDownLocation;

	private RectTransform rectTransform;

	private Image image;

	private float h;

	private float s;

	private float v;

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public event Action<Color> onColorChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initialize(Color lastColor)
	{
	}

	public void Initialize()
	{
	}

	private void Reset()
	{
	}

	private bool WrongShader()
	{
		return false;
	}

	private void Update()
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void ApplyColor()
	{
	}

	private void OnDestroy()
	{
	}

	public Vector2 GetRelativePosition(PointerEventData eventData)
	{
		return default(Vector2);
	}

	public Rect GetSquaredRect()
	{
		return default(Rect);
	}

	public float InverseLerpUnclamped(float min, float max, float value)
	{
		return 0f;
	}

	public void SetHueGamepad(bool isLeft)
	{
	}

	private float SetHueClamped(float hue)
	{
		return 0f;
	}

	public void SetSVGamepad(Vector2 dir)
	{
	}
}

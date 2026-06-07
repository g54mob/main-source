using UnityEngine;

public class DokoDemoPainterPen : MonoBehaviour
{
	[Header("Pen settings")]
	[Tooltip("The color to paint with. Setting an alpha value will make the target texture transparent. To paint at a reduced opacity, use the opacity setting below.")]
	public Color color;

	[Tooltip("The drawing size of the pen on the target texture in pixels. It will be multiplied by the DokoDemoPainterPaintable component's radiusFactor or eraserRadiusFactor.")]
	public float radius;

	[Tooltip("Allows painting at a reduced opacity. Setting this to a value other than 1.0 or enabling the smooth pen tip function will slightly reduce performance.")]
	public float opacity;

	[Tooltip("When enabled, the brush will have a smoother brush. Enabling this or setting an opacity other than 1.0 will slightly reduce performance.")]
	public bool smoothTip;

	[Tooltip("This exponent will determine how smooth or hard the brush is. Values above 1.0 make it harder. Values below make it softer.")]
	public float smoothTipExponent;

	[Tooltip("The pen will only paint while this flag is active.")]
	public bool penDown;

	[Tooltip("This flag turns the pen into an eraser. An eraser will blend the texture back to its original state rather than painting over it with a color.")]
	public bool eraser;

	[Header("Pen behaviour")]
	[Tooltip("When enabled, the pen tries to keep painting on the same texture, even when going underneath other objects.")]
	public bool keepTarget;

	[Tooltip("When enabled, you can start painting on textures where they have an alpha value of 0.")]
	public bool paintInvisible;

	[Header("Required setup")]
	[Tooltip("This camera is used to find surfaces to paint on. It may not be used for any other purpose.")]
	public Camera uvcam;

	private Shader ddpdShader;

	private RenderTexture lastPenTex;

	private int id;

	public GameObject penObj;

	public GameObject eraserObj;

	private static int nextId;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void PenUpdate()
	{
	}
}

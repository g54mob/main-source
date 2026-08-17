using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class LanternExplosion : MonoBehaviour
{
	private Material material;

	public ShakePreset shakePreset;

	public GameObject explosionFx;

	public float sizeMultiplier = 1f;

	public float lifeTime = 1f;

	public bool disableOnFinish;

	private Color startColor;

	private float startAlpha;

	private Vector3 desiredSize;

	private Vector3 startSize;

	private float myTime;

	private void Awake()
	{
		//IL_0044: Expected O, but got F4
		//IL_0056: Expected F4, but got I
		//IL_007d: Expected O, but got I4
		MeshRenderer component = GetComponent<MeshRenderer>();
		Material material = ((Renderer)component).GetMaterial();
		this.material = material;
		startColor = (Color)this.material.GetColor("_MainColor").r;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LanternExplosion)+50]");
		startAlpha = 0f;
		PlayerCamera instance = PlayerCamera.Instance;
		ShakeInstance shakeInstance = instance.shaker.Shake(shakePreset, (int?)(object)0);
		if (explosionFx != null)
		{
			Transform transform = explosionFx.transform;
			transform.parentInternal = null;
		}
	}

	public void SetRadius(float radius)
	{
		//IL_0013: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num4 = num3 * 0f;
		Vector3 vector = default(Vector3);
		desiredSize = vector;
	}

	private unsafe void OnEnable()
	{
		//IL_0013: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_00c9: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 vector = default(Vector3);
		transform.localScale = (Vector3)(&vector);
		myTime = 0f;
		object obj = default(object);
		material.SetColor("_MainColor", (Color)(&obj));
		if (explosionFx != null)
		{
			GameObject gameObject = explosionFx.gameObject;
			gameObject.SetActive(value: true);
			Transform transform2 = explosionFx.transform;
			Transform transform3 = base.transform;
			Vector3 position = transform3.position;
			transform2.position = (Vector3)(&vector);
		}
	}

	private void OnDestroy()
	{
		Object.Destroy(material);
	}

	private unsafe void FixedUpdate()
	{
		//IL_01d9: Invalid comparison between I4 and F4
		//IL_0041: Expected O, but got Ref
		//IL_009b: Invalid comparison between I4 and F4
		//IL_00e8: Expected O, but got Ref
		float t = (myTime += MyTime.fixedDeltaTime) / lifeTime;
		float num = Easing.InOutCirc(t);
		Transform transform = base.transform;
		if (0f > num || !(num > 1f))
		{
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		if (!(num < 0.8f))
		{
			Color color = material.GetColor("_MainColor");
			float num3 = num - 0.8f;
			float num4 = num3 / 0.2f;
			if (0f > num4 || num4 > 1f)
			{
			}
			material.SetColor("_MainColor", (Color)(&num2));
		}
		if (!(myTime < lifeTime))
		{
			if (!disableOnFinish)
			{
				GameObject obj = base.gameObject;
				Object.Destroy(obj);
			}
			else
			{
				explosionFx.SetActive(value: false);
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
		}
	}
}

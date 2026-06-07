using System;
using System.Collections.Generic;
using UnityEngine;

public class PortraitMaker : MonoBehaviour
{
	public class PortraitAtlas
	{
		public Texture2D Tex;

		public int Size;

		public int Used;

		public bool[,] Free;

		public int LastFree;

		public bool AnyFree
		{
			get
			{
				return Used < Free.Length;
			}
		}

		public PortraitAtlas(int size)
		{
			Size = size;
			Tex = new Texture2D(size * PortraitSize, size * PortraitSize, TextureFormat.RGB24, false);
			Free = new bool[size, size];
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Free[i, j] = true;
				}
			}
		}

		public void FreeCell(int x, int y)
		{
			if (!Free[x, y])
			{
				Free[x, y] = true;
				LastFree = y * Size + x;
				Used--;
			}
		}

		public void FreeAll()
		{
			Used = 0;
			LastFree = 0;
			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					Free[i, j] = true;
				}
			}
		}

		public Vector2Int GetFree()
		{
			for (int i = 0; i < Free.Length; i++)
			{
				int lastFree = LastFree;
				int num = lastFree % Size;
				int num2 = lastFree / Size;
				LastFree = (LastFree + 1) % Free.Length;
				if (Free[num, num2])
				{
					Free[num, num2] = false;
					Used++;
					return new Vector2Int(num, num2);
				}
			}
			throw new Exception("Tried to get free portrait cell with no free elements");
		}
	}

	public static int PortraitSize = 128;

	public static int PortraitPerAtlas = 8;

	public Camera Cam;

	public Light FlashLight;

	public AnimationCurve FlashIntensity;

	public GameObject Backdrop;

	public RenderTexture FinalTex;

	private RenderTexture LastActive;

	public Material BlitMat;

	private KeyValuePair<Renderer, int>[] _targets;

	private Dictionary<Actor, KeyValuePair<PortraitAtlas, Vector2Int>> _portraits = new Dictionary<Actor, KeyValuePair<PortraitAtlas, Vector2Int>>();

	private static List<PortraitAtlas> _portraitPool = new List<PortraitAtlas>();

	public ActorPortrait PortraitActor;

	public Animator PortraitAnim;

	public Vector3 Pos1;

	public Vector3 Pos2;

	private KeyValuePair<PortraitAtlas, Vector2Int> _hirePortrait;

	public Material BackdropMat;

	public Color[] BackdropColors;

	private KeyValuePair<PortraitAtlas, Vector2Int> GetFreeCell()
	{
		for (int i = 0; i < _portraitPool.Count; i++)
		{
			PortraitAtlas portraitAtlas = _portraitPool[i];
			if (portraitAtlas.AnyFree)
			{
				return new KeyValuePair<PortraitAtlas, Vector2Int>(portraitAtlas, portraitAtlas.GetFree());
			}
		}
		PortraitAtlas portraitAtlas2 = new PortraitAtlas(PortraitPerAtlas);
		_portraitPool.Add(portraitAtlas2);
		return new KeyValuePair<PortraitAtlas, Vector2Int>(portraitAtlas2, portraitAtlas2.GetFree());
	}

	private void Awake()
	{
		Cam.targetTexture = new RenderTexture(256, 256, 16)
		{
			antiAliasing = 1,
			autoGenerateMips = false,
			filterMode = FilterMode.Trilinear
		};
		_hirePortrait = GetFreeCell();
		Material backdropMat = (Backdrop.GetComponent<Renderer>().sharedMaterial = new Material(BackdropMat));
		BackdropMat = backdropMat;
	}

	private void OnDestroy()
	{
		for (int i = 0; i < _portraitPool.Count; i++)
		{
			_portraitPool[i].FreeAll();
		}
	}

	public void DestroyActorTex(Actor ac)
	{
		KeyValuePair<PortraitAtlas, Vector2Int> value;
		if (_portraits.TryGetValue(ac, out value))
		{
			value.Key.FreeCell(value.Value.x, value.Value.y);
			_portraits.Remove(ac);
		}
	}

	public KeyValuePair<PortraitAtlas, Vector2Int> GetActorTex(Employee emp)
	{
		RenderObject(emp, emp.StyleGen, emp.GetAge(), _hirePortrait.Key.Tex, _hirePortrait.Value.x * PortraitSize, _hirePortrait.Value.y * PortraitSize);
		return _hirePortrait;
	}

	public KeyValuePair<PortraitAtlas, Vector2Int> GetActorTex(Actor ac)
	{
		KeyValuePair<PortraitAtlas, Vector2Int> value;
		if (_portraits.TryGetValue(ac, out value))
		{
			return value;
		}
		value = GetFreeCell();
		RenderObject(ac, value.Key.Tex, value.Value.x * PortraitSize, value.Value.y * PortraitSize);
		_portraits[ac] = value;
		return value;
	}

	public void RenderObject(ActorBodyItem.BodyItemObject[] style, float age, RenderTexture rTex, int animation, Dictionary<string, float> expressions)
	{
		PortraitAnim.SetInteger("Animation", animation);
		PortraitAnim.Update(1f);
		PortraitActor.transform.localPosition = Pos2;
		Backdrop.SetActive(false);
		ActiveFurnDebug.EnableActorDraw = false;
		RenderTexture targetTexture = Cam.targetTexture;
		Cam.targetTexture = RenderTexture.GetTemporary(rTex.width * 2, rTex.height * 2);
		LastActive = RenderTexture.active;
		RenderTexture.active = Cam.targetTexture;
		PortraitActor.ApplyStyle(style, age);
		PortraitActor.SetExpression(null, true);
		PortraitActor.SetExpressions(expressions);
		FlashLight.enabled = true;
		FlashLight.intensity = FlashIntensity.Evaluate(PortraitActor.SkinColor.grayscale);
		Cam.Render();
		FlashLight.enabled = false;
		BlitMat.SetFloat("_inputSize", rTex.width * 2);
		Graphics.Blit(Cam.targetTexture, rTex, BlitMat);
		RenderTexture.active = LastActive;
		ActiveFurnDebug.EnableActorDraw = true;
		RenderTexture.ReleaseTemporary(Cam.targetTexture);
		Cam.targetTexture = targetTexture;
	}

	public void RenderObject(Employee emp, ActorBodyItem.BodyItemObject[] style, float age, Texture2D tex, int offX, int offY)
	{
		PortraitAnim.SetInteger("Animation", 0);
		PortraitAnim.Update(1f);
		PortraitActor.transform.localPosition = Pos1;
		Backdrop.SetActive(true);
		ActiveFurnDebug.EnableActorDraw = false;
		LastActive = RenderTexture.active;
		RenderTexture.active = Cam.targetTexture;
		PortraitActor.ApplyStyle(style, age);
		PortraitActor.SetExpression(emp.GetExpression(), false);
		PortraitActor.SetRotation(emp.Name);
		SetBackdrop(emp);
		FlashLight.enabled = true;
		FlashLight.intensity = FlashIntensity.Evaluate(PortraitActor.SkinColor.grayscale);
		Cam.Render();
		FlashLight.enabled = false;
		BlitMat.SetFloat("_inputSize", 256f);
		Graphics.Blit(Cam.targetTexture, FinalTex, BlitMat);
		RenderTexture.active = FinalTex;
		tex.ReadPixels(new Rect(0f, 0f, PortraitSize, PortraitSize), offX, offY, false);
		tex.Apply(false);
		RenderTexture.active = LastActive;
		ActiveFurnDebug.EnableActorDraw = true;
	}

	private void RenderObject(Actor ac, Texture2D tex, int offX, int offY)
	{
		PortraitAnim.SetInteger("Animation", 0);
		PortraitAnim.Update(1f);
		PortraitActor.transform.localPosition = Pos1;
		Backdrop.SetActive(true);
		ActiveFurnDebug.EnableActorDraw = false;
		LastActive = RenderTexture.active;
		RenderTexture.active = Cam.targetTexture;
		PortraitActor.ApplyStyle(ac);
		PortraitActor.SetExpression(ac.employee.GetExpression(), false);
		PortraitActor.SetRotation(ac.employee.Name);
		SetBackdrop(ac.employee);
		FlashLight.enabled = true;
		FlashLight.intensity = FlashIntensity.Evaluate(PortraitActor.SkinColor.grayscale);
		Cam.Render();
		FlashLight.enabled = false;
		BlitMat.SetFloat("_inputSize", 256f);
		Graphics.Blit(Cam.targetTexture, FinalTex, BlitMat);
		RenderTexture.active = FinalTex;
		tex.ReadPixels(new Rect(0f, 0f, PortraitSize, PortraitSize), offX, offY, false);
		tex.Apply(false);
		RenderTexture.active = LastActive;
		ActiveFurnDebug.EnableActorDraw = true;
	}

	private void SetBackdrop(Employee emp)
	{
		Color color = BackdropColors[0];
		if (!emp.Founder)
		{
			color = BackdropColors[(int)(emp.HiredFor + 1)];
		}
		BackdropMat.color = color;
	}
}

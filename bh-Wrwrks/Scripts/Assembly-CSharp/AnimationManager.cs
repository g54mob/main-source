using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
	public SpriteRenderer gameBG;

	public SpriteRenderer branchPopUp;

	public SpriteRenderer endlessPopUp;

	public TMP_Text endlessText;

	public Sprite[] branchSprites;

	public Sprite[] branchPopUpSprites;

	public GameObject[] transitionEffects;

	public GameObject grassContainer;

	private bool space;

	public Material shadowMat;

	public Dungeon dungeon = Dungeon.Instance;

	private Dictionary<GameObject, Coroutine> activeLerps = new Dictionary<GameObject, Coroutine>();

	public Dictionary<GameObject, Coroutine> activeZooms = new Dictionary<GameObject, Coroutine>();

	private Dictionary<GameObject, Coroutine> activeRotates = new Dictionary<GameObject, Coroutine>();

	private Coroutine tempPause;

	private List<Module> bouncingMods = new List<Module>();

	public Sprite[] gibSprites;

	public Sprite[] gibSpritesSmall;

	public GameObject gibObject;

	public Sprite[] GrassSprites;

	public GameObject GrassObj;

	public GameObject GrassParent;

	public Material lightWireMat;

	public Material darkWireMat;

	private Line prevLine;

	public GameObject lineObj;

	private int l;

	public List<Vector3> precook_scale_30 = new List<Vector3>();

	public List<Vector3> precook_scale_15 = new List<Vector3>();

	public List<Vector3> precook_spin5 = new List<Vector3>();

	public List<Vector3> precook_spin5neg = new List<Vector3>();

	public GameObject puddleObj;

	public GameObject explosionObj;

	public GameObject explosionObjAlt;

	public Material defaultMat;

	public Sprite[] dustSprites;

	public GameObject dustObj;

	public GameObject lineProjObj;

	public GameObject[] circleEffects;

	public List<GameObject> flowerObjects = new List<GameObject>();

	public GameObject numberObj;

	public int numberCount;

	public int gibCount;

	public int projGibs;

	public int projGibsAlt;

	public int lineCount;

	public int maxGibs = 200;

	public int maxGibsCap = 500;

	private const int maxNums = 300;

	public void TransitionToWater()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(transitionEffects[0]);
		gameObject.transform.position = new Vector3(-13f, -18f);
		StartCoroutine(WaterTransition(gameObject));
		Fade(gameObject, 60, 120);
		Invoke("SwitchSpritesToWater", 1.9f);
	}

	public void TransitionToSpace()
	{
		StartCoroutine(SpaceTransition());
	}

	public void TransitionToWoods()
	{
		space = false;
		StartCoroutine(WoodsTransition());
	}

	public IEnumerator WaterTransition(GameObject t)
	{
		float f = 0f;
		dungeon.audioManager.PlaySound(AudioManager.Sound.Water_Waves);
		for (int i = 0; i < 120; i++)
		{
			t.transform.localPosition += new Vector3(0.1f, 0.15f + 0.2f * Mathf.Sin(f));
			f += 0.1f;
			yield return Wait(1);
		}
	}

	public IEnumerator WoodsTransition()
	{
		Vector3 OP_player = dungeon.player.transform.position;
		dungeon.player.spriteRenderer.sortingOrder += 9999;
		dungeon.player.spriteRenderer.GetComponent<DropShadow>().spriteRenderer.sortingOrder += 9999;
		Vector3 tar = new Vector3(-9f, -11f);
		dungeon.player.spriteRenderer.sprite = branchSprites[2];
		gameBG.sprite = branchSprites[3];
		LerpZoom(dungeon.player.gameObject, new Vector3(100f, 100f), 80f);
		LerpTo(dungeon.player.gameObject, tar, 120);
		yield return Wait(80);
		dungeon.player.spriteRenderer.sortingOrder += -9999;
		dungeon.player.spriteRenderer.GetComponent<DropShadow>().spriteRenderer.sortingOrder += -9999;
		SpriteRenderer t = UnityEngine.Object.Instantiate(transitionEffects[1]).GetComponent<SpriteRenderer>();
		Color oc = (t.color = Utils.GetColor("5AC54F"));
		Color dc = Utils.GetColor("272727");
		float cl = 60f;
		for (float i = 0f; i < cl; i += 1f)
		{
			t.color = Color.Lerp(oc, dc, (i + 1f) / cl);
			yield return Wait(1);
		}
		gameBG.transform.localPosition = Vector3.zero;
		UnityEngine.Object.Destroy(t.gameObject);
		dungeon.player.transform.position = OP_player;
		dungeon.player.transform.localScale = Vector3.zero;
		dungeon.player.spriteRenderer.sprite = branchSprites[4];
		gameBG.sprite = branchSprites[5];
		LerpZoom(dungeon.player.gameObject, Vector3.one);
		SpriteRenderer[] componentsInChildren = grassContainer.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer spriteRenderer in componentsInChildren)
		{
			spriteRenderer.color = Utils.GetColor("3D3D3D");
			LerpZoom(spriteRenderer.gameObject, Vector3.one);
		}
		yield return Wait(30);
		StartCoroutine(PopUpBranch(0));
	}

	public IEnumerator SpaceTransition()
	{
		int num = 40;
		LerpZoom(dungeon.player.gameObject, Vector3.zero, num);
		SpriteRenderer[] componentsInChildren = grassContainer.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer spriteRenderer in componentsInChildren)
		{
			LerpZoom(spriteRenderer.gameObject, Vector3.zero, num);
		}
		yield return Wait(num);
		SpriteRenderer t = UnityEngine.Object.Instantiate(transitionEffects[1]).GetComponent<SpriteRenderer>();
		Color oc = t.color;
		Color dc = Utils.GetColor("0098DC");
		float cl = 60f;
		for (float i2 = 0f; i2 < cl; i2 += 1f)
		{
			t.color = Color.Lerp(oc, dc, (i2 + 1f) / cl);
			yield return Wait(1);
		}
		StartCoroutine(SpaceBGAnim());
		UnityEngine.Object.Destroy(t.gameObject);
		dungeon.player.transform.localScale = Vector3.one;
		dungeon.player.spriteRenderer.transform.localScale = new Vector3(100f, 100f);
		Vector3 position = dungeon.player.transform.position;
		dungeon.player.transform.localPosition = new Vector3(9f, 8f);
		dungeon.player.spriteRenderer.sprite = branchSprites[2];
		dungeon.player.spriteRenderer.sortingOrder += 9999;
		dungeon.player.spriteRenderer.GetComponent<DropShadow>().spriteRenderer.sortingOrder += 9999;
		gameBG.sprite = branchSprites[3];
		LerpZoom(dungeon.player.spriteRenderer.gameObject, Vector3.one);
		LerpTo(dungeon.player.gameObject, position);
		yield return Wait(30);
		dungeon.player.spriteRenderer.sortingOrder += -9999;
		dungeon.player.spriteRenderer.GetComponent<DropShadow>().spriteRenderer.sortingOrder += -9999;
		StartCoroutine(PopUpBranch(2));
	}

	public IEnumerator SpaceBGAnim()
	{
		space = true;
		gameBG.transform.localPosition = new Vector3(30.5f, 0f, 0f);
		Vector3 op = gameBG.transform.localPosition;
		while (space)
		{
			for (int i = 0; i < 255; i++)
			{
				if (!space)
				{
					yield break;
				}
				gameBG.transform.localPosition += new Vector3(-0.0625f, 0f);
				yield return Wait(180);
			}
			gameBG.transform.localPosition = op;
		}
	}

	private void SwitchSpritesToWater()
	{
		dungeon.player.spriteRenderer.sprite = branchSprites[0];
		gameBG.sprite = branchSprites[1];
		Color color = Utils.GetColor("2A2F4E");
		SpriteRenderer[] componentsInChildren = grassContainer.GetComponentsInChildren<SpriteRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = color;
		}
		StartCoroutine(PopUpBranch(1));
	}

	public IEnumerator PopUpBranch(int x, bool skip = false)
	{
		if (!skip)
		{
			yield return Wait(30);
		}
		branchPopUp.sprite = dungeon.currentLocale.branchPopups[x];
		yield return LerpZoom(branchPopUp.gameObject, Vector3.one, 12f, 0.1f);
		if (dungeon.endlessLevel == 0)
		{
			yield return Wait(90);
			yield return LerpZoom(branchPopUp.gameObject, Vector3.zero, 12f);
			yield break;
		}
		yield return Wait(20);
		endlessText.text = $"{dungeon.GetText(LocalizationManager.Text.Loop)} {dungeon.endlessLevel + 1}";
		yield return LerpZoom(endlessPopUp.gameObject, Vector3.one, 12f, 0.1f);
		yield return Wait(70);
		yield return LerpZoom(branchPopUp.gameObject, Vector3.zero, 12f);
		yield return LerpZoom(endlessPopUp.gameObject, Vector3.zero, 12f);
	}

	public void InstantWater()
	{
		dungeon.player.spriteRenderer.sprite = branchSprites[0];
		gameBG.sprite = branchSprites[1];
		Color color = Utils.GetColor("2A2F4E");
		SpriteRenderer[] componentsInChildren = grassContainer.GetComponentsInChildren<SpriteRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = color;
		}
		dungeon.audioManager.SwitchMusic(AudioManager.Music.Shop_Water);
	}

	public void InstantSpace()
	{
		SpriteRenderer[] componentsInChildren = grassContainer.GetComponentsInChildren<SpriteRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.transform.localScale = Vector3.zero;
		}
		dungeon.player.spriteRenderer.sprite = branchSprites[2];
		gameBG.sprite = branchSprites[3];
		space = true;
		StartCoroutine(SpaceBGAnim());
		dungeon.audioManager.SwitchMusic(AudioManager.Music.Shop_Orbit);
	}

	public static IEnumerator Wait(int x)
	{
		for (int i = 0; i < x; i++)
		{
			while (Dungeon.Instance.paused)
			{
				yield return null;
			}
			yield return null;
		}
	}

	public static IEnumerator WaitUI(int x)
	{
		for (int i = 0; i < x; i++)
		{
			yield return null;
		}
	}

	public void HitEffect(int frames)
	{
		tempPause = StartCoroutine(TempPause(frames));
	}

	public void PauseGame()
	{
		if (tempPause != null)
		{
			StopCoroutine(tempPause);
		}
		dungeon.paused = true;
	}

	private IEnumerator TempPause(int x)
	{
		for (int i = 0; i < x; i++)
		{
			dungeon.paused = true;
			yield return null;
		}
		dungeon.paused = false;
	}

	public void Screenshake(float x = -1f, float y = -1f, int frames = 3)
	{
		if (dungeon.saveData.screenshake)
		{
			if (x == -1f)
			{
				x = Utils.RandSign(0.0625f);
			}
			if (y == -1f)
			{
				y = Utils.RandSign(0.0625f);
			}
			Dungeon.Instance.animationManager.StartCoroutine(screenshaker(x, y, frames));
		}
	}

	public IEnumerator screenshaker(float x, float y, int frames = 3)
	{
		Camera.main.transform.localPosition += new Vector3(x, y);
		Camera.main.transform.localEulerAngles += new Vector3(0f, 0f, x * 2f);
		for (int i = 0; i < frames; i++)
		{
			yield return null;
		}
		Camera.main.transform.localPosition -= new Vector3(x, y);
		Camera.main.transform.localEulerAngles -= new Vector3(0f, 0f, x * 2f);
	}

	public void LerpTo(MonoBehaviour obj, Vector3 tar, int frameCount = 30, float bounce = 0f, bool slerp = false, bool destroy = false, bool UI = false)
	{
		LerpTo(obj.gameObject, tar, frameCount, bounce, slerp, destroy, UI);
	}

	public Coroutine LerpTo(GameObject obj, Vector3 tar, int frameCount = 30, float bounce = 0f, bool slerp = false, bool destroy = false, bool UI = false)
	{
		if (activeLerps.ContainsKey(obj))
		{
			if (activeLerps[obj] == null)
			{
				activeLerps.Remove(obj);
			}
			else
			{
				Coroutine routine = activeLerps[obj];
				activeLerps.Remove(obj);
				StopCoroutine(routine);
			}
		}
		Coroutine coroutine = StartCoroutine(_lerpTo(obj, tar, frameCount, bounce, slerp, destroy, UI));
		activeLerps.Add(obj, coroutine);
		return coroutine;
	}

	public void EndMovement(GameObject obj)
	{
		if (activeLerps.ContainsKey(obj))
		{
			StopCoroutine(activeLerps[obj]);
			activeLerps.Remove(obj);
		}
	}

	private IEnumerator _lerpTo(GameObject obj, Vector3 tar, float frameCount = 30f, float bounce = 0f, bool slerp = false, bool destroy = false, bool UI = false)
	{
		Vector3 OP = obj.transform.localPosition;
		Vector3 DP = tar;
		Vector3 normalized = (DP - OP).normalized;
		DP += normalized * bounce;
		for (int i = 0; (float)i < frameCount; i++)
		{
			if (obj == null)
			{
				break;
			}
			if (slerp)
			{
				obj.transform.localPosition = Vector3.Slerp(OP, DP, (float)(i + 1) / frameCount);
			}
			else
			{
				obj.transform.localPosition = Vector3.Lerp(OP, DP, (float)(i + 1) / frameCount);
			}
			if (UI)
			{
				yield return WaitUI(1);
			}
			else
			{
				yield return Wait(1);
			}
		}
		if (bounce > 0f)
		{
			OP = obj.transform.localPosition;
			DP = tar;
			float bframes = 3f;
			for (int i = 0; (float)i < bframes; i++)
			{
				if (obj == null)
				{
					break;
				}
				obj.transform.localPosition = Vector3.Lerp(OP, DP, (float)(i + 1) / bframes);
				if (UI)
				{
					yield return WaitUI(1);
				}
				else
				{
					yield return Wait(1);
				}
			}
		}
		if (activeLerps.ContainsKey(obj))
		{
			activeLerps.Remove(obj);
		}
		if (destroy)
		{
			UnityEngine.Object.Destroy(obj);
		}
	}

	public Coroutine LerpZoom(GameObject obj, Vector3 tar, float frameCount = 30f, float bounce = 0f, bool destroy = false, bool UI = false)
	{
		if (activeZooms.ContainsKey(obj))
		{
			if (activeZooms[obj] == null)
			{
				activeZooms.Remove(obj);
			}
			else
			{
				Coroutine routine = activeZooms[obj];
				activeZooms.Remove(obj);
				StopCoroutine(routine);
			}
		}
		Coroutine coroutine = StartCoroutine(_lerpZoom(obj, tar, frameCount, bounce, destroy, UI));
		activeZooms.Add(obj, coroutine);
		return coroutine;
	}

	private IEnumerator _lerpZoom(GameObject obj, Vector3 tar, float frameCount = 30f, float bounce = 0f, bool destroy = false, bool UI = false)
	{
		Vector3 OP = obj.transform.localScale;
		Vector3 DP = tar;
		Vector3 normalized = (DP - OP).normalized;
		DP += normalized * bounce;
		for (int i = 0; (float)i < frameCount; i++)
		{
			if (obj == null)
			{
				break;
			}
			obj.transform.localScale = Vector3.Lerp(OP, DP, (float)(i + 1) / frameCount);
			if (UI)
			{
				yield return WaitUI(1);
			}
			else
			{
				yield return Wait(1);
			}
		}
		if (bounce > 0f && obj != null)
		{
			OP = obj.transform.localScale;
			DP = tar;
			float bframes = 3f;
			for (int i = 0; (float)i < bframes; i++)
			{
				if (obj == null)
				{
					break;
				}
				obj.transform.localScale = Vector3.Lerp(OP, DP, (float)(i + 1) / bframes);
				if (UI)
				{
					yield return WaitUI(1);
				}
				else
				{
					yield return Wait(1);
				}
			}
		}
		if (activeZooms.ContainsKey(obj))
		{
			activeZooms.Remove(obj);
		}
		if (destroy)
		{
			UnityEngine.Object.Destroy(obj);
		}
	}

	public Coroutine LerpRotate(GameObject obj, Vector3 tar, float frameCount = 30f, float bounce = 0f, bool UI = false)
	{
		if (activeRotates.ContainsKey(obj))
		{
			if (activeRotates[obj] == null)
			{
				activeRotates.Remove(obj);
			}
			else
			{
				Coroutine routine = activeRotates[obj];
				activeRotates.Remove(obj);
				StopCoroutine(routine);
			}
		}
		Coroutine coroutine = StartCoroutine(_lerpRotate(obj, tar, frameCount, bounce, UI));
		activeRotates.Add(obj, coroutine);
		return coroutine;
	}

	private IEnumerator _lerpRotate(GameObject obj, Vector3 tar, float frameCount = 30f, float bounce = 0f, bool UI = false)
	{
		Vector3 OP = obj.transform.localEulerAngles;
		Vector3 DP = tar;
		while (DP.z > 360f)
		{
			DP -= new Vector3(0f, 0f, 360f);
		}
		while (OP.z > 360f)
		{
			OP -= new Vector3(0f, 0f, 360f);
		}
		while (DP.z < 0f)
		{
			DP += new Vector3(0f, 0f, 360f);
		}
		while (OP.z < 0f)
		{
			OP += new Vector3(0f, 0f, 360f);
		}
		if (DP.z > OP.z + 180f)
		{
			DP -= new Vector3(0f, 0f, 360f);
		}
		if (OP.z > DP.z + 180f)
		{
			OP -= new Vector3(0f, 0f, 360f);
		}
		Vector3 normalized = (DP - OP).normalized;
		DP += normalized * bounce;
		for (int i = 0; (float)i < frameCount; i++)
		{
			if (obj == null)
			{
				break;
			}
			obj.transform.localEulerAngles = Vector3.Lerp(OP, DP, (float)(i + 1) / frameCount);
			if (UI)
			{
				yield return WaitUI(1);
			}
			else
			{
				yield return Wait(1);
			}
		}
		if (bounce > 0f)
		{
			OP = obj.transform.localEulerAngles;
			DP = tar;
			float bframes = 3f;
			for (int i = 0; (float)i < bframes; i++)
			{
				if (obj == null)
				{
					break;
				}
				obj.transform.localEulerAngles = Vector3.Lerp(OP, DP, (float)(i + 1) / bframes);
				if (UI)
				{
					yield return WaitUI(1);
				}
				else
				{
					yield return Wait(1);
				}
			}
		}
		if (activeRotates.ContainsKey(obj))
		{
			activeRotates.Remove(obj);
		}
	}

	public void BounceZoom(GameObject g, float bounce, int frames = 3, bool modWire = false, bool UI = false)
	{
		StartCoroutine(bounceZoom(g, bounce, frames, modWire, UI));
	}

	private IEnumerator bounceZoom(GameObject g, float bounce, float frames, bool modW, bool UI = false)
	{
		if (modW)
		{
			Module component = g.GetComponent<Module>();
			if (bouncingMods.Contains(component))
			{
				yield break;
			}
			bouncingMods.Add(component);
			if (component.dragging || component.clickMoving)
			{
				yield break;
			}
			Plug[] plugs = component.plugs;
			foreach (Plug plug in plugs)
			{
				if (!(plug == null) && (plug.owner == null || plug.owner.swapAnim || (plug.connectedPlug != null && (plug.connectedPlug.owner.swapAnim || plug.connectedPlug.owner.dragging || plug.connectedPlug.owner.clickMoving))))
				{
					yield break;
				}
			}
			g.GetComponent<Module>().DragPlugs();
		}
		for (int j = 0; (float)j < frames; j++)
		{
			if (g == null)
			{
				yield break;
			}
			g.transform.localScale += Vector3.one * bounce / frames;
			if (UI)
			{
				yield return WaitUI(1);
			}
			else
			{
				yield return Wait(1);
			}
		}
		for (int j = 0; (float)j < frames; j++)
		{
			if (g == null)
			{
				yield break;
			}
			g.transform.localScale += Vector3.one * (0f - bounce) / frames;
			if (UI)
			{
				yield return WaitUI(1);
			}
			else
			{
				yield return Wait(1);
			}
		}
		if (modW)
		{
			g.GetComponent<Module>().EndDragPlugs();
			bouncingMods.Remove(g.GetComponent<Module>());
			g.transform.localScale = Vector3.one;
		}
	}

	public Coroutine Spin(GameObject g, float speed, int frames = 0)
	{
		return StartCoroutine(_spinner(g, speed, frames));
	}

	private IEnumerator _spinner(GameObject g, float speed, int frames)
	{
		if (frames == 0)
		{
			while (!(g == null))
			{
				g.transform.localEulerAngles += new Vector3(0f, 0f, speed);
				yield return Wait(1);
			}
			yield break;
		}
		for (int i = 0; i < frames; i++)
		{
			if (g == null)
			{
				break;
			}
			g.transform.localEulerAngles += new Vector3(0f, 0f, speed);
			yield return Wait(1);
		}
	}

	public void MoveDir(GameObject g, Vector3 dir, float speed, int frames = -1)
	{
		StartCoroutine(_moveDir(g, dir, speed, frames));
	}

	private IEnumerator _moveDir(GameObject g, Vector3 dir, float speed, int frames)
	{
		int i = 0;
		float v = speed;
		while (!(g == null))
		{
			g.transform.localPosition += dir * speed;
			i++;
			if (frames > 0)
			{
				speed -= v / (float)frames;
			}
			if (i != frames)
			{
				yield return Dungeon.Wait(1);
				continue;
			}
			break;
		}
	}

	public static void PointTo(GameObject g, Vector3 target, float ang = 0f)
	{
		float num = 180f / MathF.PI * Mathf.Atan2(g.transform.position.y - target.y, g.transform.localPosition.x - target.x);
		num += ang;
		g.transform.localEulerAngles = new Vector3(0f, 0f, num);
	}

	public void Fade(GameObject g, int frames, int delay = 0, bool destroy = true)
	{
		StartCoroutine(_fadeout(g, frames, delay, destroy));
	}

	private IEnumerator _fadeout(GameObject g, int frames, int delay = 0, bool destroy = true)
	{
		yield return Wait(delay);
		if (g == null)
		{
			yield break;
		}
		SpriteRenderer s = g.GetComponentsInChildren<SpriteRenderer>()[0];
		for (int i = 0; i < frames; i++)
		{
			if (s == null)
			{
				yield break;
			}
			s.color += new Color(0f, 0f, 0f, -1f / (float)frames);
			if (g.GetComponents<DropShadow>().Length != 0)
			{
				g.GetComponent<DropShadow>().spriteRenderer.color += new Color(0f, 0f, 0f, -1 / frames);
			}
			yield return Wait(1);
		}
		if (destroy)
		{
			UnityEngine.Object.Destroy(g.gameObject);
		}
	}

	public void CreateGibs(string color, Vector3 position, float count = 5f, float scale = 1f, bool unmasked = false, float speedMult = 1f)
	{
		if (!unmasked)
		{
			if (gibCount > maxGibs)
			{
				count /= 2f;
			}
			if (gibCount > maxGibsCap)
			{
				count = 0f;
			}
		}
		for (int i = 0; (float)i < count; i++)
		{
			float f = Mathf.Lerp(0f, MathF.PI * 2f, UnityEngine.Random.Range(0f, 1f));
			Vector3 vector = position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) * 0.25f;
			SpriteRenderer component = UnityEngine.Object.Instantiate(gibObject).GetComponent<SpriteRenderer>();
			if (unmasked)
			{
				component.maskInteraction = SpriteMaskInteraction.None;
				component.sortingLayerName = "WidgetElevated";
				component.sortingOrder = 9999;
			}
			component.transform.position = vector;
			MoveDir(component.gameObject, (vector - position).normalized, speedMult * UnityEngine.Random.Range(0.02f, 0.06f), UnityEngine.Random.Range(i * 2 + 10, i * 2 + 20));
			Spin(component.gameObject, (float)((!(vector.x > position.x)) ? 1 : (-1)) * UnityEngine.Random.Range(5f, 20f));
			component.sprite = Utils.RandElem(gibSprites);
			component.color = Utils.GetColor(color);
			component.transform.localScale *= scale;
			StartCoroutine(gibBounce(component.gameObject));
		}
	}

	private IEnumerator gibBounce(GameObject s, float scale = 1f, bool flash = true, int frames = 15)
	{
		SpriteRenderer spriteRenderer = s.GetComponent<SpriteRenderer>();
		s.transform.localScale = Vector3.one * 0.5f * scale;
		BounceZoom(s, 0.4f, 4);
		Color col = spriteRenderer.color;
		if (flash)
		{
			spriteRenderer.color = Color.white;
		}
		yield return Dungeon.Wait(2);
		spriteRenderer.color = col;
		yield return Dungeon.Wait(2);
		LerpZoom(s, Vector3.zero, frames);
		Fade(s, 1, frames);
	}

	public void CreateFallingGibs(string color, Vector3 position, float count = 5f, float scale = 1f, bool unmasked = false, float speedMult = 1f, float angle = -1f, bool oldStyle = false)
	{
		for (int i = 0; (float)i < count; i++)
		{
			float f = ((angle == -1f) ? 4.712389f : angle);
			Vector3 vector = position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) * 0.25f;
			SpriteRenderer component = UnityEngine.Object.Instantiate(gibObject).GetComponent<SpriteRenderer>();
			if (unmasked)
			{
				component.maskInteraction = SpriteMaskInteraction.None;
				component.sortingLayerName = "WidgetElevated";
				component.sortingOrder = 9999;
			}
			component.transform.position = vector;
			MoveDir(component.gameObject, (vector - position).normalized, speedMult * UnityEngine.Random.Range(0.02f, 0.06f), UnityEngine.Random.Range(i * 2 + 10, i * 2 + 20));
			Spin(component.gameObject, ((!(vector.x > position.x)) ? 1 : (-1)) * 5);
			component.sprite = Utils.RandElem(oldStyle ? gibSprites : gibSpritesSmall);
			component.color = Utils.GetColor(color) - new Color(0f, 0f, 0f, 0.15f);
			component.transform.localScale *= scale;
			StartCoroutine(gibBounce(component.gameObject, scale, flash: false, 30));
		}
	}

	public void CreateGrass()
	{
		Vector3 mousePos = Plug.GetMousePos();
		SpriteRenderer component = UnityEngine.Object.Instantiate(GrassObj).GetComponent<SpriteRenderer>();
		component.sprite = Utils.RandElem(GrassSprites);
		component.transform.position = mousePos;
		component.flipX = Utils.RNG(50f);
	}

	public IEnumerator pointpicker()
	{
		bool drawing = false;
		Vector3 pos = Vector3.zero;
		List<Line> undos = new List<Line>();
		while (true)
		{
			Input.GetKeyDown(KeyCode.P);
			if (Input.GetKeyDown(KeyCode.G))
			{
				if (!drawing)
				{
					l--;
					drawing = true;
					pos = Plug.GetMousePos();
					prevLine = null;
				}
				else
				{
					drawing = false;
					undos.Insert(0, prevLine);
					prevLine = null;
				}
			}
			if (Input.GetKeyDown(KeyCode.Z) && undos.Count != 0)
			{
				if (undos[0] != null)
				{
					UnityEngine.Object.Destroy(undos[0].gameObject);
				}
				undos.RemoveAt(0);
			}
			if (drawing)
			{
				if (prevLine != null)
				{
					UnityEngine.Object.Destroy(prevLine.gameObject);
				}
				prevLine = ConnectLine(pos, Plug.GetMousePos());
			}
			if (Input.GetKeyDown(KeyCode.H) && undos.Count != 0)
			{
				undos[0].line.material = lightWireMat;
				undos[0].line.materials[0] = lightWireMat;
			}
			yield return Wait(1);
		}
	}

	public void CreateWireBG()
	{
	}

	public Line ConnectLine(Vector2 pos, Vector2 target)
	{
		GameObject obj = UnityEngine.Object.Instantiate(lineObj);
		Line component = obj.GetComponent<Line>();
		component.line.sortingOrder = -50 + l;
		component.highlight.enabled = false;
		component.line.sortingLayerName = "Default";
		LineRenderer line = component.line;
		float startWidth = (component.line.endWidth = 0.5f);
		line.startWidth = startWidth;
		component.line.numCapVertices = 5;
		component.line.numCornerVertices = 5;
		DrawLine(component, pos, target);
		component.hitbox.enabled = false;
		obj.name = "BG_Line";
		return component;
	}

	private void DrawLine(Line line, Vector2 pos, Vector2 target)
	{
		line.Clear();
		foreach (Vector2 item in GetCable(pos, target))
		{
			line.UpdateLine(item);
		}
	}

	public List<Vector2> GetCable(Vector2 pos, Vector2 target)
	{
		List<Vector2> list = new List<Vector2>();
		if (pos.x == target.x)
		{
			list.Add(pos);
			list.Add(Vector2.Lerp(pos, target, 0.25f));
			list.Add(Vector2.Lerp(pos, target, 0.75f));
			list.Add(target);
			return list;
		}
		float num = Mathf.Abs(pos.y - target.y) / 2f;
		float num2 = Mathf.Abs(pos.x - target.x);
		float num3 = Mathf.Sign(target.x - pos.x);
		float num4 = Mathf.Sign(target.y - pos.y);
		Vector2 vector = pos;
		Vector2 vector2 = target;
		bool flag;
		if ((num3 < 0f && num4 > 0f) || (num3 > 0f && num4 < 0f))
		{
			flag = false;
			if (num3 < 0f)
			{
				vector = target;
				vector2 = pos;
			}
		}
		else
		{
			flag = true;
			if (num3 > 0f)
			{
				vector = target;
				vector2 = pos;
			}
		}
		float num5 = 40f;
		for (int i = 0; (float)i < num5; i++)
		{
			Vector2 item = default(Vector2);
			float num6 = Mathf.Lerp(0f, num2, (float)i / (num5 - 1f));
			float f = MathF.PI * (1f / num2 * num6 + 0.5f);
			float num7 = num * Mathf.Sin(f);
			item = new Vector2(num6 * (float)((!flag) ? 1 : (-1)) + vector.x, (vector.y + vector2.y) / 2f + num7);
			list.Add(item);
		}
		return list;
	}

	public void FlashSprite(GameObject g, int f = 5)
	{
		StartCoroutine(flasher(g, f));
	}

	private IEnumerator flasher(GameObject g, int f = 5)
	{
		Material default_mat = g.GetComponent<SpriteRenderer>().material;
		g.GetComponent<SpriteRenderer>().material = dungeon.shadowMat;
		yield return Wait(f);
		g.GetComponent<SpriteRenderer>().material = default_mat;
	}

	public void Precook()
	{
		for (int i = 0; i < 30; i++)
		{
			precook_scale_30.Add(Vector3.Lerp(Vector3.one, Vector3.zero, (float)(i + 1) / 30f));
		}
		for (int j = 0; j < 15; j++)
		{
			precook_scale_15.Add(Vector3.Lerp(Vector3.one, Vector3.zero, (float)(j + 1) / 15f));
		}
		for (int k = 0; k < 70; k++)
		{
			precook_spin5.Add(new Vector3(0f, 0f, 5 * k));
			precook_spin5neg.Add(new Vector3(0f, 0f, -5 * k));
		}
	}

	public Projectile CreateCircleEffect(Vector3 pos, string color, Vector3 scale)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(circleEffects[0]);
		gameObject.transform.localScale = Vector3.zero;
		LerpZoom(gameObject, scale, 8f, 0.2f);
		gameObject.GetComponent<Animator>().StopAnim(force: true);
		gameObject.GetComponent<Animator>().StartAnimOneShot(stopOnLastFrame: true);
		gameObject.GetComponent<SpriteRenderer>().color = Utils.GetColor(color);
		Fade(gameObject, 2, 20);
		gameObject.transform.position = pos;
		return gameObject.GetComponent<Projectile>();
	}

	public void FlashSprite(SpriteRenderer s, int frames = 10)
	{
		StartCoroutine(Flasher(s, frames));
	}

	private IEnumerator Flasher(SpriteRenderer s, int frames)
	{
		Color oc = s.color;
		s.material = Dungeon.Instance.shadowMat;
		s.color = Color.white;
		yield return Wait(frames);
		s.material = defaultMat;
		s.color = oc;
	}

	public Projectile CreatePuddle(string color1, string color2, int duration)
	{
		Projectile component = UnityEngine.Object.Instantiate(puddleObj).GetComponent<Projectile>();
		component.transform.localScale = Vector3.zero;
		LerpZoom(component.gameObject, Vector3.one, 7f, 0.125f);
		StartCoroutine(PuddleBehavior(component.gameObject, color1, color2));
		StartCoroutine(DelayedZoomout(component.gameObject, duration));
		return component;
	}

	private IEnumerator PuddleBehavior(GameObject g, string cs1, string cs2)
	{
		SpriteRenderer s = g.GetComponent<SpriteRenderer>();
		float a = 0.15f;
		float t = 0f;
		Color c1 = Utils.GetColor(cs1);
		Color c2 = Utils.GetColor(cs2);
		int i = 0;
		while (g != null)
		{
			s.color = Color.Lerp(c1, c2, 0.5f + 0.5f * Mathf.Sin(t + MathF.PI / 2f));
			t += a;
			g.GetComponent<Rigidbody2D>().simulated = i < 10;
			i++;
			if (i == 40)
			{
				i = 0;
			}
			yield return Wait(1);
		}
	}

	public Projectile CreateExplosion(string colorBG, string colorBorder, int duration, bool insta = false, bool ticks = false, bool spin = true, bool shake = true, int ticker = 40, bool alt = false)
	{
		Projectile component = UnityEngine.Object.Instantiate(alt ? explosionObjAlt : explosionObj).GetComponent<Projectile>();
		component.transform.localScale = (insta ? Vector3.one : Vector3.zero);
		float num = (float)dungeon.board.CountAuras(Aura.Type.PerkBomber) * 0.2f;
		if (insta)
		{
			component.transform.localEulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(-5f, 5f));
			BounceZoom(component.gameObject, 0.125f, 4);
			if (shake)
			{
				Screenshake();
			}
			StartCoroutine(upscaler(component.gameObject, num));
		}
		else
		{
			LerpZoom(component.gameObject, Vector3.one + num * Vector3.one, 5f, 0.125f);
		}
		component.GetComponentsInChildren<SpriteRenderer>()[0].color = Utils.GetColor(colorBG);
		Spin(component.gameObject, 0.125f * (float)Utils.RandSign());
		StartCoroutine(DelayedFlickerOut(component.gameObject, duration));
		StartCoroutine(ExplosionBehavior(component.gameObject, colorBG, colorBorder, ticks, ticker));
		return component;
	}

	private IEnumerator upscaler(GameObject g, float f)
	{
		yield return Wait(1);
		g.transform.localScale += f * Vector3.one;
	}

	private IEnumerator ExplosionBehavior(GameObject g, string color1, string color2, bool ticks = true, int ticker = 40)
	{
		g.GetComponent<SpriteRenderer>();
		int i = 0;
		while (g != null)
		{
			if (i == 5)
			{
				g.GetComponentsInChildren<SpriteRenderer>()[0].color = Utils.GetColor(color1);
				g.GetComponentsInChildren<SpriteRenderer>()[1].color = Utils.GetColor(color2);
			}
			g.GetComponent<Rigidbody2D>().simulated = i < 10;
			i++;
			if (i == ticker && ticks)
			{
				i = 0;
				BounceZoom(g, -0.05f);
				g.GetComponentsInChildren<SpriteRenderer>()[1].color = Color.white;
			}
			yield return Wait(1);
		}
	}

	public void DestroyZoom(GameObject g, int f)
	{
		StartCoroutine(DelayedZoomout(g, f));
	}

	private IEnumerator DelayedZoomout(GameObject g, int frames)
	{
		yield return Wait(frames);
		yield return LerpZoom(g, Vector3.zero, 10f);
		UnityEngine.Object.Destroy(g.gameObject);
	}

	private IEnumerator DelayedFlickerOut(GameObject g, int frames)
	{
		if (frames >= 0)
		{
			yield return Wait(frames);
			g.SetActive(value: false);
			yield return Wait(5);
			g.SetActive(value: true);
			yield return Wait(10);
			UnityEngine.Object.Destroy(g.gameObject);
		}
	}

	public void CreateNumber(int val, Vector3 pos, Number.Type type, string customColor = "")
	{
		if (numberCount <= 300)
		{
			Number component = UnityEngine.Object.Instantiate(numberObj).GetComponent<Number>();
			component.transform.position = pos;
			component.Set(val, type, pos, customColor);
		}
	}

	public void TossEffect(GameObject g, Vector3 DP, int frames, bool destroy = true, float heightMod = 0.5f, bool dust = false)
	{
		StartCoroutine(tosser(g, DP, frames, destroy, heightMod, dust));
	}

	private IEnumerator tosser(GameObject g, Vector3 DP, int frames, bool destroy, float heightMod, bool dust)
	{
		DropShadow ds = null;
		if (g.GetComponents<DropShadow>().Length != 0)
		{
			ds = g.GetComponent<DropShadow>();
		}
		Vector3 OP = g.transform.position;
		if (!dust)
		{
			Spin(g, ((!(OP.x < DP.x)) ? 1 : (-1)) * 5, frames);
		}
		else
		{
			StartCoroutine(DustCook(g, OP.x < DP.x));
		}
		float num = Vector3.Distance(OP, DP);
		float sqrtA = num / 2f;
		Vector2 offset = new Vector2(ds.offset.x, ds.offset.y);
		for (int i = 0; i < frames; i++)
		{
			if (g == null)
			{
				yield break;
			}
			Vector3 vector = Vector3.Lerp(OP, DP, ((float)i + 1f) / (float)frames);
			float num2 = 0f - sqrtA + (1f + (float)i) / (float)frames * 2f * sqrtA;
			float num3 = heightMod * (sqrtA * sqrtA - num2 * num2);
			if (ds != null)
			{
				ds.offset = offset + new Vector2(0f, 0f - num3);
			}
			g.transform.position = vector + new Vector3(0f, num3);
			yield return Wait(1);
		}
		if (destroy)
		{
			UnityEngine.Object.Destroy(g);
		}
	}

	public void CreateDust(Vector3 pos, string color = "3D3D3D", int count = 10, float scale = 1f)
	{
		CreateDust(pos, Utils.GetColor(color), count, scale);
	}

	public void CreateDust(Vector3 pos, Color color, int count = 10, float scale = 1f)
	{
		if (gibCount > maxGibs)
		{
			count = 3;
		}
		if (gibCount > maxGibsCap)
		{
			count = 0;
		}
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(dustObj);
			gameObject.GetComponent<SpriteRenderer>().sprite = Utils.RandElem(dustSprites);
			gameObject.transform.localScale = Vector3.one * scale;
			gameObject.transform.position = pos;
			TossEffect(gameObject, pos + Utils.RandDir() * UnityEngine.Random.Range(2f, 3f), 60, destroy: true, 0.5f, dust: true);
			gameObject.GetComponent<SpriteRenderer>().color = color;
		}
	}

	private IEnumerator DustCook(GameObject g, bool neg)
	{
		for (int i = 0; i < 30; i++)
		{
			g.transform.localScale = precook_scale_30[i];
			g.transform.localEulerAngles = (neg ? precook_spin5neg[i] : precook_spin5[i]);
			yield return Wait(1);
		}
	}

	public void CreatePermaGibs(string color, Vector3 position, float count = 5f, float scale = 1f, bool unmasked = false)
	{
		for (int i = 0; (float)i < count; i++)
		{
			float f = Mathf.Lerp(0f, MathF.PI * 2f, UnityEngine.Random.Range(0f, 1f));
			Vector3 vector = position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) * 0.25f;
			SpriteRenderer component = UnityEngine.Object.Instantiate(gibObject).GetComponent<SpriteRenderer>();
			if (unmasked)
			{
				component.maskInteraction = SpriteMaskInteraction.None;
				component.sortingLayerName = "WidgetElevated";
				component.sortingOrder = 9999;
			}
			component.transform.position = vector;
			MoveDir(component.gameObject, (vector - position).normalized, UnityEngine.Random.Range(0.02f, 0.06f), UnityEngine.Random.Range(i * 2 + 10, i * 2 + 20));
			Spin(component.gameObject, (float)((!(vector.x > position.x)) ? 1 : (-1)) * UnityEngine.Random.Range(5f, 20f), 6);
			component.sprite = Utils.RandElem(gibSprites);
			component.color = Utils.GetColor(color);
			component.transform.localScale *= scale;
			TossEffect(component.gameObject, position + Utils.RandDir() * UnityEngine.Random.Range(0.25f, 0.75f), 7, destroy: false, 0.25f);
		}
	}

	public void CreateLaser(List<Vector3> points, string color, float width = 0.3f)
	{
		UnityEngine.Object.Instantiate(dungeon.LightningEffect).GetComponent<LightningEffect>().SetPointsStraight(points, color, width);
	}

	public void CreateLightning(List<Vector3> points, string color, bool silent = false, bool unmasked = false)
	{
		UnityEngine.Object.Instantiate(dungeon.LightningEffect).GetComponent<LightningEffect>().SetPoints(points, color, silent, unmasked);
	}

	public void CreateWave(Vector3 a, Vector3 b, string color, float width = 0.3f, bool silent = false, bool unmasked = false)
	{
		UnityEngine.Object.Instantiate(dungeon.LightningEffect).GetComponent<LightningEffect>().SetPointsWave(a, b, color, width, unmasked);
	}

	public Projectile CreateSpark(Vector3 op, Vector3 pp, string color)
	{
		ProjectileLine component = UnityEngine.Object.Instantiate(lineProjObj).GetComponent<ProjectileLine>();
		LineRenderer line = component.line;
		float startWidth = (component.line.endWidth = 0.125f);
		line.startWidth = startWidth;
		LineRenderer line2 = component.line;
		Color startColor = (component.line.endColor = Utils.GetColor(color));
		line2.startColor = startColor;
		List<Vector3> list = new List<Vector3>();
		list.Add(op);
		list.Add(pp);
		List<Vector3> list2 = new List<Vector3>();
		int num2 = 0;
		foreach (Vector3 item3 in list)
		{
			list2.Add(item3);
			num2++;
			if (item3 == list[^1])
			{
				break;
			}
			Vector3 vector = list[num2];
			float num3 = Vector3.Distance(vector, item3);
			if (!(Vector3.Distance(vector, item3) < 0.5f))
			{
				_ = (vector - item3).normalized;
				float num4 = Mathf.Atan2(0f - item3.y + vector.y, 0f - item3.x + vector.x);
				float f = num4 + MathF.PI / 180f * (float)UnityEngine.Random.Range(5, 20);
				float f2 = num4 - MathF.PI / 180f * (float)UnityEngine.Random.Range(5, 20);
				float num5 = UnityEngine.Random.Range(0.1f, 0.5f);
				float num6 = UnityEngine.Random.Range(num5 + 0.2f, 0.8f);
				Vector3 item = item3 + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) * num3 * num5;
				Vector3 item2 = item3 + new Vector3(Mathf.Cos(f2), Mathf.Sin(f2)) * num3 * num6;
				list2.Add(item);
				list2.Add(item2);
			}
		}
		foreach (Vector3 item4 in list2)
		{
			component.UpdateLine(item4);
		}
		component.StartFade();
		return component.projectile;
	}
}

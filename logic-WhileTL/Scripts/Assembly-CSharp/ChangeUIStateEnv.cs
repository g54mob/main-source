using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIStateEnv : ActiveComponent
{
	public List<GameObject> objects = new List<GameObject>();

	private Image selfImg;

	private SpriteRenderer selfRenderer;

	public bool clickable;

	public List<Sprite> sprites = new List<Sprite>();

	public List<Sprite> mobileSprites = new List<Sprite>();

	public List<float> scores = new List<float>();

	public List<int> skips = new List<int>();

	private float maxScores;

	private int curStability;

	private int curState;

	public float rand;

	protected override void OnInit()
	{
		maxScores = 0f;
		foreach (float score in scores)
		{
			maxScores += score;
		}
		curStability = 0;
		selfImg = base.gameObject.GetComponent<Image>();
		selfRenderer = base.gameObject.GetComponent<SpriteRenderer>();
		if (clickable)
		{
			base.gameObject.GetComponent<Button>().onClick.AddListener(NextState);
		}
	}

	private void NextState()
	{
		curState++;
		curState %= scores.Count;
		curStability = skips[curState];
		Redraw(curState);
	}

	private void Active(GameObject go, bool state)
	{
		if (!(go == null))
		{
			go.SetActive(state);
		}
	}

	private void Active(Sprite sprite, bool state)
	{
		if (!(sprite == null) && state)
		{
			if (selfImg != null)
			{
				selfImg.sprite = sprite;
			}
			if (selfRenderer != null)
			{
				selfRenderer.sprite = sprite;
				float num = 128f / (float)sprite.texture.height;
				base.gameObject.GetComponent<RectTransform>().sizeDelta /= num;
				base.gameObject.transform.localScale *= num;
			}
		}
	}

	public void Redraw()
	{
		Random.InitState((int)(Time.time * 100f));
		curStability--;
		if (curStability > 0)
		{
			return;
		}
		rand = Random.Range(0f, maxScores);
		float num = 0f;
		curState = 0;
		for (int i = 0; i < scores.Count; i++)
		{
			num += scores[i];
			if (num > rand)
			{
				curState = i;
				curStability = skips[i];
				break;
			}
		}
		Redraw(curState);
	}

	public void Redraw(int state)
	{
		if (objects.Count != 0)
		{
			for (int i = 0; i < scores.Count; i++)
			{
				Active(objects[i], i == state);
			}
		}
		else
		{
			if (sprites.Count == 0)
			{
				return;
			}
			for (int j = 0; j < scores.Count; j++)
			{
				if (false)
				{
					Active(mobileSprites[j], j == state);
				}
				else
				{
					Active(sprites[j], j == state);
				}
			}
		}
	}
}

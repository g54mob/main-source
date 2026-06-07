using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public int defaultButtonBounce = 2;

	public virtual void BounceButton(UIButton b, int f = 2, bool silent = false)
	{
		StartCoroutine(bouncer(b, f));
	}

	private IEnumerator bouncer(UIButton b, int f = 2)
	{
		bool sorter = true;
		if (Dungeon.Instance.mainmenu.anim != Mainmenu.animState.None)
		{
			sorter = false;
		}
		if (sorter)
		{
			b.GetComponent<SpriteRenderer>().sortingOrder += 5;
		}
		for (int i = 0; i < f; i++)
		{
			b.transform.localPosition += new Vector3(0f, 0.0625f);
			b.GetComponent<BoxCollider2D>().offset += new Vector2(0f, -0.0625f);
			yield return AnimationManager.WaitUI(1);
		}
		for (int i = 0; i < f; i++)
		{
			yield return AnimationManager.WaitUI(1);
			b.transform.localPosition -= new Vector3(0f, 0.0625f);
			b.GetComponent<BoxCollider2D>().offset -= new Vector2(0f, -0.0625f);
		}
		if (sorter)
		{
			b.GetComponent<SpriteRenderer>().sortingOrder += -5;
		}
	}

	public virtual void CloseEffect()
	{
	}
}

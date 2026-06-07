using UnityEngine;
using UnityEngine.UI;

public class AmmoItem : MonoBehaviour
{
	public Image Img;

	public RectTransform Xfm;

	private HeroInst _hero;

	public int Idx;

	private Color _c;

	private bool _isLoaded;

	public void Init(HeroInst h)
	{
	}

	public void InitCopy(AmmoItem toCopy)
	{
	}

	public HeroInst GetHero()
	{
		return null;
	}

	public void RefreshLoadedState()
	{
	}

	public void SetLoaded(bool isLoaded)
	{
	}

	public bool IsLoaded()
	{
		return false;
	}
}

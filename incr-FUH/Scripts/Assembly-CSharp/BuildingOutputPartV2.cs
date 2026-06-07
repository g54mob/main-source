using UnityEngine;

public class BuildingOutputPartV2 : MonoBehaviour
{
	public BuildingOutputV2 Parent;

	public GameObject OutputLocation;

	public DustGenerator DustGenerator;

	public ParticleSystem SmallDustParticle;

	public AnimationSprite MainAnimation;

	private Sprite _originalSprite;

	private SpriteRenderer _renderer;

	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		if (_renderer != null)
		{
			_originalSprite = GetComponent<SpriteRenderer>().sprite;
		}
	}

	public void ChangeSprite(Sprite sprite)
	{
		if (_renderer != null)
		{
			if (sprite == null)
			{
				GetComponent<SpriteRenderer>().sprite = _originalSprite;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = sprite;
			}
		}
		if (MainAnimation != null)
		{
			MainAnimation.ResetOriginalSprite();
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent)
		{
			Parent.ProcessClick();
		}
	}
}

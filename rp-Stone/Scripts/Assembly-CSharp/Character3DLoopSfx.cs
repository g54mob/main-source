using UnityEngine;

[RequireComponent(typeof(Character))]
public class Character3DLoopSfx : MonoBehaviour
{
	public string sfxId;

	public float distanceCoeficient = 1f;

	public bool playOffScreen;

	private Character myCharacter;

	private AsciiSprite mySprite;

	private Transform sfxTransform;

	private bool drewLastFrame;

	public Sfx sfxLoop { get; private set; }

	private void Update()
	{
		if (!LoadingAccountant.IsBusy())
		{
			InitSfx();
			UpdateSfxPosition();
			UpdateVolume();
		}
	}

	private void InitSfx()
	{
		if (!(sfxLoop != null) && !(SfxController.singleton == null) && SfxController.singleton.HasPreloaded(sfxId))
		{
			sfxLoop = SfxController.singleton.Play(sfxId, ignoreDuplicateSfxInSameFrame: false);
			if (sfxLoop != null)
			{
				sfxTransform = sfxLoop.GetComponent<Transform>();
				UpdateSfxPosition();
			}
		}
	}

	private void UpdateSfxPosition()
	{
		if (sfxTransform != null)
		{
			Vector3 position = sfxTransform.position;
			position.x = ((drewLastFrame || playOffScreen) ? (DistanceToHero() * distanceCoeficient) : 9999f);
			sfxTransform.position = position;
		}
	}

	private void UpdateVolume()
	{
		if (sfxLoop != null)
		{
			sfxLoop.SetVolume(SfxController.singleton.volume);
		}
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character == myCharacter && sfxLoop != null)
		{
			sfxLoop.Stop();
			sfxLoop = null;
		}
	}

	private float DistanceToHero()
	{
		return myCharacter.PositionX - GameStates.Singleton.hero.PositionX;
	}

	private void HandleOnDraw(Character c, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		AsciiSprite asciiSprite = c.MySprite;
		drewLastFrame = asciiSprite != null && asciiSprite.lastDrawX + c.MySprite.width >= 0 && asciiSprite.lastDrawX < r.width && asciiSprite.lastDrawY + c.MySprite.height >= 0 && asciiSprite.lastDrawY < r.height;
	}

	private void OnDisable()
	{
		if (sfxLoop != null)
		{
			sfxLoop.gameObject.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		if (sfxLoop != null)
		{
			sfxLoop.gameObject.SetActive(value: true);
		}
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
		if (myCharacter != null)
		{
			myCharacter.OnPostDrawCharacter -= HandleOnDraw;
		}
		if (sfxLoop != null)
		{
			sfxLoop.Stop();
			sfxLoop = null;
		}
		myCharacter = null;
		sfxTransform = null;
	}

	private void Awake()
	{
		SfxController.singleton.Preload(sfxId);
		myCharacter = GetComponent<Character>();
		mySprite = GetComponent<AsciiSprite>();
		Character.OnCharacterDied += HandleOnCharacterDied;
		myCharacter.OnPostDrawCharacter += HandleOnDraw;
	}
}

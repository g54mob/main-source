using ClockStone;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
	private bool finishedIntro;

	private float initialWait = 1f;

	private float scaleTime = 0.45f;

	private string anykeyPressedSound = "mainMenu_anyKeyPressed";

	private Inchworm inchRef;

	private void Awake()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		inchRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetGameLocation(GameLocation.MAIN_MENU);
	}

	private void Update()
	{
		if (!finishedIntro && initialWait > 0f)
		{
			initialWait -= Time.deltaTime;
			if (initialWait <= 0f)
			{
				IntroBounce();
			}
		}
		HandleInput();
	}

	private void IntroBounce()
	{
		GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<InchwormBounce>().enabled = false;
		base.gameObject.transform.localScale = Vector3.zero;
		inchRef.RequestEaseToScale(base.gameObject, Vector3.one, scaleTime, Inchworm.EaseStyle.ElasticOut, BounceCallback);
	}

	private void BounceCallback()
	{
		finishedIntro = true;
		GetComponent<InchwormBounce>().enabled = true;
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<BoxCollider2D>().enabled = true;
	}

	private void HandleInput()
	{
		if (Input.anyKeyDown && !GameControls.actions.Interact.WasPressed)
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerTitleScreen>(GlobalObject.GUI).ShowFileSelectGUI();
			base.gameObject.SetActive(value: false);
			AudioController.Play(anykeyPressedSound);
		}
	}
}

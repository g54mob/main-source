using System.Collections;
using System.Collections.Generic;
using Assets.Behaviour.UI;
using Assets.Source.Player;
using Assets.Source.World;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Behaviour.Frame.Parts
{
	public class GlitchedFrameScreen : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _background;

		[SerializeField]
		private List<Sprite> _backgroundSprites;

		[SerializeField]
		private GlitchedFrameObject[] _glitchPrefabs;

		[SerializeField]
		private TMP_Text _label;

		[SerializeField]
		private FrameButton _button;

		[SerializeField]
		private FrameGizmoShaker _shaker;

		private float _backgroundTimer;

		private float _objectTimer;

		private void Start()
		{
			SteamAchievement.Trigger("GlitchFrame");
			int num = SeededRandom.Global.RandomRange(5, 10);
			for (int i = 0; i < num; i++)
			{
				_spawnGlitch();
			}
		}

		private void Update()
		{
			_backgroundTimer -= Time.deltaTime;
			if (_backgroundTimer < 0f)
			{
				_background.sprite = SeededRandom.Global.Choose(_backgroundSprites);
				_backgroundTimer = SeededRandom.Global.RandomRange(0.5f, 3f);
				_background.flipY = SeededRandom.Global.RandomBool();
			}
			_objectTimer -= Time.deltaTime;
			if (_objectTimer < 0f)
			{
				_spawnGlitch();
				_objectTimer = SeededRandom.Global.RandomRange(0.3f, 0.7f);
			}
			if (!_button.gameObject.activeSelf && Keyboard.current.yKey.wasPressedThisFrame)
			{
				this.StartImportantCoroutine(_doResetUniverse());
			}
		}

		private IEnumerator _doResetUniverse()
		{
			_label.TL("@GlitchedFrameProgress1");
			UISounds.CraftStep();
			GetComponent<ActiveWorldFrame>().TriggerCooldown(new WorldAnchor(WorldAnchorType.Custom, 0), 2.8f);
			yield return new WaitForSeconds(3f);
			_button.gameObject.SetActive(value: true);
			_label.TL("@GlitchedFrameProgress2");
			UISounds.CraftFinished();
			yield return null;
		}

		private void _spawnGlitch()
		{
			GlitchedFrameObject glitchedFrameObject = Object.Instantiate(SeededRandom.Global.Choose(_glitchPrefabs), new Vector3(SeededRandom.Global.RandomRange(-9f, 9f), SeededRandom.Global.RandomRange(-5.4f, 1.7f), -1f), Quaternion.identity, base.transform);
			if (SeededRandom.Global.RandomBool())
			{
				float num = SeededRandom.Global.RandomRange(0.5f, 1.2f);
				glitchedFrameObject.transform.localScale = new Vector3(num, num);
			}
		}

		public void ButtonPress()
		{
			this.StartImportantCoroutine(_clearGlitchedFrame());
		}

		public IEnumerator _clearGlitchedFrame()
		{
			_button.SetActive(active: false);
			_shaker.ForceActive = true;
			yield return new WaitForSeconds(0.5f);
			UIStatusMessage.Show("@StatusMessageGlitchFrame", "Items_45", persistent: false);
			yield return new WaitForSeconds(3f);
			GamePlayer.Current.GlitchFrameInteracted = true;
			WorldMap.Current.RemoveFrame(GetComponent<ActiveWorldFrame>().ActiveFrame);
			GameUI.Instance.ShowFullScreenUI(OverviewUI.Instance);
			UIStatusMessage.Show("@NewTechDiscovered", "Items_45", persistent: false);
			yield return null;
		}
	}
}

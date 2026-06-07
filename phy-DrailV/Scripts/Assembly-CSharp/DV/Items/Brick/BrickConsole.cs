using System.Collections;
using System.Collections.Generic;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickConsole : MonoBehaviour
	{
		public const float TICK_INTERVAL = 1f / 30f;

		private const float AUTO_POWER_OFF_ON_GAME_ENDED_DELAY = 3f;

		private BrickScreen screen;

		private BrickAssets assets;

		private BrickInput input;

		private BrickAudio audio;

		private bool isOn;

		private BrickRom loadedRom;

		private BrickRom introRom;

		private BrickRom dodgeCarsRom;

		private List<BrickRom> roms = new List<BrickRom>();

		private Coroutine dodgeCarsEndedCoroutine;

		private float tickTimer;

		private void Start()
		{
			screen = GetComponent<BrickScreen>();
			if (screen == null)
			{
				Debug.LogError("BrickConsole: BrickScreen component not found! Brick got bricked!", this);
				return;
			}
			input = GetComponent<BrickInput>();
			if (input == null)
			{
				Debug.LogError("BrickConsole: BrickInput component not found! Brick got bricked!", this);
				return;
			}
			audio = GetComponent<BrickAudio>();
			if (audio == null)
			{
				Debug.LogError("BrickConsole: BrickAudio component not found! Brick got bricked!", this);
				return;
			}
			assets = new BrickAssets();
			input.InputAction += ExecuteInputAction;
			dodgeCarsRom = new BrickRomDodgeCars(assets, screen, audio, SingletonBehaviour<UserManager>.Instance.CurrentUser);
			introRom = new BrickRomIntro(assets, screen, audio);
			roms.Add(dodgeCarsRom);
			roms.Add(introRom);
			introRom.GameEnded += OnIntroEnded;
			dodgeCarsRom.GameEnded += OnDodgeCarsEnded;
			dodgeCarsRom.GameStarted += OnDodgeCarsStarted;
		}

		private void OnIntroEnded()
		{
			if (isOn)
			{
				loadedRom = dodgeCarsRom;
				loadedRom.ExecuteInput(BrickInput.BrickInputAction.PowerOn);
			}
		}

		private void OnDodgeCarsEnded()
		{
			if (isOn)
			{
				if (dodgeCarsEndedCoroutine != null)
				{
					StopCoroutine(dodgeCarsEndedCoroutine);
				}
				dodgeCarsEndedCoroutine = StartCoroutine(OnDodgeCarsEndedDelayed());
			}
		}

		private void OnDodgeCarsStarted()
		{
			if (isOn && dodgeCarsEndedCoroutine != null)
			{
				StopCoroutine(dodgeCarsEndedCoroutine);
			}
		}

		private IEnumerator OnDodgeCarsEndedDelayed()
		{
			yield return WaitFor.Seconds(3f);
			if (isOn)
			{
				input.ForceButtonPress(BrickInput.BrickButton.Power);
			}
			dodgeCarsEndedCoroutine = null;
		}

		private void OnDestroy()
		{
			if (input != null)
			{
				input.InputAction -= ExecuteInputAction;
			}
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading && isOn && !(input == null))
			{
				input.ForceButtonPress(BrickInput.BrickButton.Power);
			}
		}

		private void Update()
		{
			if (isOn && loadedRom != null)
			{
				tickTimer += Time.deltaTime;
				while (tickTimer > 1f / 30f)
				{
					loadedRom.Tick();
					tickTimer -= 1f / 30f;
				}
			}
		}

		public void ExecuteInputAction(BrickInput.BrickInputAction brickInputAction)
		{
			switch (brickInputAction)
			{
			case BrickInput.BrickInputAction.Up:
			case BrickInput.BrickInputAction.Down:
			case BrickInput.BrickInputAction.Left:
			case BrickInput.BrickInputAction.Right:
			case BrickInput.BrickInputAction.Pause:
			case BrickInput.BrickInputAction.Resume:
			case BrickInput.BrickInputAction.Restart:
				if (isOn && loadedRom != null)
				{
					loadedRom.ExecuteInput(brickInputAction);
				}
				break;
			case BrickInput.BrickInputAction.PowerOn:
				SetPower(on: true);
				break;
			case BrickInput.BrickInputAction.PowerOff:
				SetPower(on: false);
				break;
			}
		}

		private void SetPower(bool on)
		{
			if (isOn != on)
			{
				isOn = on;
				if (on)
				{
					loadedRom = introRom;
				}
				else if (loadedRom == null)
				{
					return;
				}
				tickTimer = 0f;
				BrickInput.BrickInputAction action = (isOn ? BrickInput.BrickInputAction.PowerOn : BrickInput.BrickInputAction.PowerOff);
				loadedRom.ExecuteInput(action);
			}
		}
	}
}

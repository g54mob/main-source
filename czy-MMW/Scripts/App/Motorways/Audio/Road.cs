using System;
using Motorways.Models;
using UnityEngine;

namespace Motorways.Audio
{
	public class Road : Playback
	{
		private bool _success;

		private bool skip;

		public bool Success
		{
			get
			{
				return _success;
			}
			set
			{
				skip = !_success && !value;
				_success = value;
			}
		}

		public Road(AudioEventFilter filter)
			: base(filter)
		{
		}

		protected override void OnPulse()
		{
			if (GetEvents())
			{
				while (audioEvents.Count > 1 && audioEvents[0].Type == AudioEventType.BuildRoad)
				{
					audioEvents.RemoveAt(0);
				}
				Success = audioEvents[0].Condition;
				HandleEvent(audioEvents[0]);
				audioEvents.Clear();
			}
		}

		private void HandleEvent(AudioEvent e)
		{
			if (skip)
			{
				return;
			}
			string text = null;
			Param.Group obj = new Param.Group();
			UpgradeDatabaseModel model = Get.Game.Simulation.GetModel<UpgradeDatabaseModel>();
			int num = 20;
			int num2 = Math.Min(model.GetAvailableUpgradeCount(UpgradeType.Concrete), num);
			float t = ((num2 > 1) ? ((float)num2 / (float)num) : 0f);
			switch (e.Type)
			{
			case AudioEventType.BuildBridge:
				text = (e.Condition ? "Draw-Bridge" : "sineFX_04");
				obj = (e.Condition ? Settings.BUILD_BRIDGE : Settings.DELETE_ROAD);
				break;
			case AudioEventType.BuildTunnel:
				text = (e.Condition ? "Draw-Tunnel" : "sineFX_04");
				obj = (e.Condition ? Settings.BUILD_TUNNEL : Settings.DELETE_ROAD);
				break;
			case AudioEventType.BuildRoad:
				text = (e.Condition ? "DrawRoad" : "sineFX_04");
				obj = (e.Condition ? Settings.BUILD_ROAD : Settings.DELETE_ROAD);
				if (e.Condition)
				{
					obj.Pitch.Range.x = Mathf.Lerp(0.75f, 1f, t);
					obj.Pitch.Range.y = Mathf.Lerp(0.75f, 1.25f, t);
				}
				break;
			case AudioEventType.MothballRoad:
				text = "EraseRoad";
				obj = Settings.MOTHBALL_ROAD;
				obj.Gain.Range = obj.Gain.Range.Swap();
				obj.Pitch.Range.x = Mathf.Lerp(1f, 1.25f, t);
				obj.Pitch.Range.y = Mathf.Lerp(1f, 1.5f, t);
				break;
			case AudioEventType.TreeBulldozed:
				text = "Bulldoze-Tree-0" + Rando.Pick<string>("1", "2");
				obj = Settings.BULLDOZE_TREE;
				Get.Mixbus.BoingPitchInPlace(Rando.Range(1f, 4f), Rando.Pick<float>(0.5f, 1f, 1.5f), Settings.PITCH_TREE_BULLDOZED.Random(), 0.5f);
				break;
			}
			if (text != null)
			{
				AudioPlayer.UI.PlaySample(text, 0.5f, Mathf.Lerp(obj.Gain.Range.x, obj.Gain.Range.y, SFX.MouseSpeed), Mathf.Lerp(obj.Pitch.Range.x, obj.Pitch.Range.y, SFX.MouseSpeed), 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
			}
		}
	}
}

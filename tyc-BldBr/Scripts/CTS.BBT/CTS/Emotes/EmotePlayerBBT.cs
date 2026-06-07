using CTS.Core;
using UnityEngine;

namespace CTS.Emotes
{
	public class EmotePlayerBBT : EmotePlayer
	{
		[Inject(false)]
		private RoomObject _roomData;

		private static readonly int _unityGUIZTestMode = Shader.PropertyToID("unity_GUIZTestMode");

		protected override void OnAwake()
		{
			base.OnAwake();
			_defaultSpriteMaterial.SetInt(_unityGUIZTestMode, 8);
			_defaultBackgroundMaterial.SetInt(_unityGUIZTestMode, 8);
		}

		public void SetRoomParent(RoomObject roomParent)
		{
			_roomData.SetParent(roomParent);
		}

		public void SetRoom(RoomObject room)
		{
			SetRoom(room.CurrentRoom);
		}

		public void SetRoom(RoomBuilding room)
		{
			SetRoomParent(null);
			_roomData.CurrentRoom = room;
		}

		protected override void Init(Emote emote)
		{
			base.Init(emote);
			if (emote is EmoteBBT emoteBBT)
			{
				if ((bool)emoteBBT.ParentRoomData)
				{
					SetRoomParent(emoteBBT.ParentRoomData);
				}
				else if ((bool)emoteBBT.RoomRef)
				{
					SetRoom(emoteBBT.RoomRef);
				}
			}
		}

		protected override void OnPushedToPool()
		{
			base.OnPushedToPool();
			if (base.gameObject.scene.isLoaded)
			{
				SetRoomParent(null);
			}
		}
	}
}

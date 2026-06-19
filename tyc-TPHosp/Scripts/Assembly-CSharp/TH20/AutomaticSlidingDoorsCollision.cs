using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AutomaticSlidingDoorsCollision : EntityTickComponent
	{
		private const float SearchRadius = 5f;

		private RoomItem _roomItem;

		public Vector3 _position;

		public Room _room;

		[DontSave]
		private List<Character> _charactersEnter;

		[DontSave]
		private List<Character> _charactersExit;

		[DontSave]
		private List<AutomaticSlidingDoorsComponent> _automaticSlidingDoorComponentsCached;

		[DontSave]
		private AutomaticSlidingDoorsComponent _automaticSlidingDoors;

		private static List<AutomaticSlidingDoorsCollision> _allDoors;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		private void AddToProcessList()
		{
			if (_allDoors == null)
			{
				_allDoors = new List<AutomaticSlidingDoorsCollision>();
			}
			_allDoors.Add(this);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
			_charactersEnter = new List<Character>();
			_charactersExit = new List<Character>();
			_automaticSlidingDoorComponentsCached = new List<AutomaticSlidingDoorsComponent>();
			AddToProcessList();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			_charactersEnter = new List<Character>();
			_charactersExit = new List<Character>();
			_automaticSlidingDoorComponentsCached = new List<AutomaticSlidingDoorsComponent>();
			AddToProcessList();
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_allDoors != null)
			{
				_allDoors.Remove(this);
			}
		}

		public static void Tick(CharacterManager characterManager)
		{
			if (_allDoors == null)
			{
				return;
			}
			float num = 25f;
			foreach (AutomaticSlidingDoorsCollision allDoor in _allDoors)
			{
				allDoor.ClearCharactersEntering();
			}
			foreach (Character allCharacter in characterManager.AllCharacters)
			{
				Vector3 position = allCharacter.Position;
				Room roomUsing = allCharacter.RoomUsing;
				foreach (AutomaticSlidingDoorsCollision allDoor2 in _allDoors)
				{
					if ((roomUsing == null || roomUsing == allDoor2._room) && position.SquareDistance2D(allDoor2._position) < num)
					{
						allDoor2.CharacterEnter(allCharacter);
					}
				}
			}
			foreach (AutomaticSlidingDoorsCollision allDoor3 in _allDoors)
			{
				allDoor3.ProcessCharactersExiting();
			}
		}

		private void ClearCharactersEntering()
		{
			_charactersEnter.Clear();
		}

		private void CharacterEnter(Character character)
		{
			_charactersEnter.Add(character);
			if (!_charactersExit.Remove(character) && _automaticSlidingDoors != null)
			{
				_automaticSlidingDoors.OnCharacterEnter();
			}
		}

		private void ProcessCharactersExiting()
		{
			if (_automaticSlidingDoors != null)
			{
				for (int i = 0; i < _charactersExit.Count; i++)
				{
					_automaticSlidingDoors.OnCharacterExit();
				}
			}
			_charactersExit.Clear();
			foreach (Character item in _charactersEnter)
			{
				_charactersExit.Add(item);
			}
		}

		public override void Tick()
		{
			base.Tick();
			_room = _roomItem.OwningRoom;
			_position = _roomItem.WorldPosition;
			if (_roomItem.Visual != null && _automaticSlidingDoors == null)
			{
				_roomItem.Visual.GameObject.GetComponents(_automaticSlidingDoorComponentsCached);
				_automaticSlidingDoors = ((_automaticSlidingDoorComponentsCached.Count > 0) ? _automaticSlidingDoorComponentsCached[0] : null);
				_automaticSlidingDoorComponentsCached.Clear();
			}
		}
	}
}

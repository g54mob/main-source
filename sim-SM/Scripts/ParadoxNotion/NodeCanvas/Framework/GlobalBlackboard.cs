using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[ExecuteInEditMode]
	public class GlobalBlackboard : Blackboard, IGlobalBlackboard, IBlackboard
	{
		public enum SingletonMode
		{
			DestroyComponentOnly = 0,
			DestroyEntireGameObject = 1
		}

		[SerializeField]
		private string _UID;

		[Tooltip("A *unique* identifier of this Global Blackboard")]
		[SerializeField]
		private string _identifier;

		[Tooltip("If a duplicate with the same identifier is encountered, destroy the previous Global Blackboard component only, or the previous Global Blackboard gameobject entirely?")]
		[SerializeField]
		private SingletonMode _singletonMode;

		[Tooltip("If true, the Global Blackboard will not be destroyed when another scene is loaded.")]
		[SerializeField]
		private bool _dontDestroyOnLoad;

		private static List<GlobalBlackboard> _allGlobals;

		public string identifier => null;

		public string UID => null;

		public new string name => null;

		public static IEnumerable<GlobalBlackboard> GetAll()
		{
			return null;
		}

		public static GlobalBlackboard Create()
		{
			return null;
		}

		public static GlobalBlackboard Find(string name)
		{
			return null;
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected override void OnValidate()
		{
		}

		public override string ToString()
		{
			return null;
		}

		private bool IsPrefabAsset()
		{
			return false;
		}
	}
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CTS.APITwitch
{
	[CreateAssetMenu(fileName = "ListNameTwitch", menuName = "BBT/API Twitch")]
	public class EventName : ScriptableObject
	{
		[SerializeField]
		private int _maxName;

		[SerializeField]
		private bool _wantWantingNameList;

		[SerializeField]
		private List<string> _nameList = new List<string>();

		private List<string> _nameAlreadyUsed = new List<string>();

		public void ClearTheList()
		{
			if (_nameList != null)
			{
				_nameList.Clear();
			}
			if (_nameAlreadyUsed != null)
			{
				_nameAlreadyUsed.Clear();
			}
		}

		public void ChangeMaxName(int maxName)
		{
			_maxName = maxName;
		}

		public void CleanUsedListName()
		{
			if (_nameAlreadyUsed != null)
			{
				_nameAlreadyUsed.Clear();
			}
		}

		private void CheckList(string name)
		{
			if (_nameList.Count < _maxName)
			{
				if (!_nameList.Contains(name) && !_nameAlreadyUsed.Contains(name))
				{
					_nameList.Add(name);
					Debug.Log("Le nom " + name + " a été ajouté à la liste.");
				}
				else
				{
					Debug.Log("Le nom " + name + " existe déjà dans la liste.");
				}
			}
			else
			{
				Debug.Log(" Trop de nom dans la liste : " + _nameList.ToString());
			}
		}

		public string GetTheFirstName()
		{
			if (_nameList[0] != null)
			{
				string text = _nameList[0];
				_nameList.RemoveAt(0);
				_nameAlreadyUsed.Add(text);
				Debug.Log("I Use :  " + text);
				return text;
			}
			return null;
		}

		public bool ListHasName()
		{
			if (_nameList.Count <= 0)
			{
				return false;
			}
			return true;
		}

		public void OnChatMessage(string pChatter, string pMessage)
		{
			Debug.Log(pChatter);
			Task.Run(delegate
			{
				CheckList(pChatter);
			});
		}
	}
}

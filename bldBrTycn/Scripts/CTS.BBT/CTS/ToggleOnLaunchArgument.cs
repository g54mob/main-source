using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ToggleOnLaunchArgument : CTSBehaviour
	{
		public enum EActivationType
		{
			SetActive = 0,
			SetInactive = 1,
			Destroy = 2
		}

		public enum EType
		{
			ArgumentValue = 0,
			Active = 1,
			Inactive = 2
		}

		[SerializeField]
		private string _command;

		[SerializeField]
		private bool _editorValue;

		[SerializeField]
		private EType _devBuildValue;

		[SerializeField]
		private SerializableDictionary<EActivationType, GameObject[]> _onCommandFound;

		[SerializeField]
		private SerializableDictionary<EActivationType, GameObject[]> _onCommandNotFound;

		protected override void OnAwake()
		{
			base.OnAwake();
			SearchInArguments();
		}

		private void SearchInArguments()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			foreach (string b in commandLineArgs)
			{
				if (string.Equals(_command, b, StringComparison.InvariantCultureIgnoreCase))
				{
					OnCommandFound(found: true);
					return;
				}
			}
			OnCommandFound(found: false);
		}

		private void OnCommandFound(bool found)
		{
			if (found)
			{
				RunList(_onCommandFound.Dict);
			}
			else
			{
				RunList(_onCommandNotFound.Dict);
			}
			static void RunList(Dictionary<EActivationType, GameObject[]> list)
			{
				foreach (KeyValuePair<EActivationType, GameObject[]> item in list)
				{
					item.Deconstruct(out var key, out var value);
					EActivationType eActivationType = key;
					GameObject[] array = value;
					switch (eActivationType)
					{
					case EActivationType.SetActive:
					{
						value = array;
						for (int i = 0; i < value.Length; i++)
						{
							value[i].SetActive(value: true);
						}
						break;
					}
					case EActivationType.SetInactive:
					{
						value = array;
						for (int i = 0; i < value.Length; i++)
						{
							value[i].SetActive(value: false);
						}
						break;
					}
					case EActivationType.Destroy:
					{
						value = array;
						for (int i = 0; i < value.Length; i++)
						{
							UnityEngine.Object.Destroy(value[i]);
						}
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
					}
				}
			}
		}
	}
}

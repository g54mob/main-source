using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class CollectorListVariable
	{
		private enum Type
		{
			LocalList = 0,
			GlobalList = 1
		}

		[SerializeField]
		private Type m_ListVariable;

		[SerializeField]
		private PropertyGetGameObject m_LocalList = new PropertyGetGameObject();

		[SerializeField]
		private GlobalListVariables m_GlobalList;

		public List<object> Get(Args args)
		{
			List<object> list = new List<object>();
			switch (m_ListVariable)
			{
			case Type.LocalList:
			{
				LocalListVariables localListVariables = m_LocalList.Get<LocalListVariables>(args);
				if (localListVariables != null)
				{
					for (int j = 0; j < localListVariables.Count; j++)
					{
						list.Add(localListVariables.Get(j));
					}
				}
				break;
			}
			case Type.GlobalList:
				if (m_GlobalList != null)
				{
					for (int i = 0; i < m_GlobalList.Count; i++)
					{
						list.Add(m_GlobalList.Get(i));
					}
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return list;
		}

		public int GetCount(Args args)
		{
			switch (m_ListVariable)
			{
			case Type.LocalList:
			{
				LocalListVariables localListVariables = m_LocalList.Get<LocalListVariables>(args);
				if (!(localListVariables != null))
				{
					return 0;
				}
				return localListVariables.Count;
			}
			case Type.GlobalList:
				if (!(m_GlobalList != null))
				{
					return 0;
				}
				return m_GlobalList.Count;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public IdString GetTypeId(Args args)
		{
			switch (m_ListVariable)
			{
			case Type.LocalList:
			{
				LocalListVariables localListVariables = m_LocalList.Get<LocalListVariables>(args);
				if (!(localListVariables != null))
				{
					return ValueNull.TYPE_ID;
				}
				return localListVariables.TypeID;
			}
			case Type.GlobalList:
				if (!(m_GlobalList != null))
				{
					return ValueNull.TYPE_ID;
				}
				return m_GlobalList.TypeID;
			default:
				return ValueNull.TYPE_ID;
			}
		}

		public void Fill(GameObject[] gameObjects, Args args)
		{
			object[] array = new object[gameObjects.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = gameObjects[i];
			}
			Fill(array, args);
		}

		public void Fill(object[] values, Args args)
		{
			switch (m_ListVariable)
			{
			case Type.LocalList:
			{
				LocalListVariables localListVariables = m_LocalList.Get<LocalListVariables>(args);
				if (localListVariables == null)
				{
					break;
				}
				localListVariables.Clear();
				object[] array = values;
				foreach (object obj2 in array)
				{
					if (obj2 != null)
					{
						localListVariables.Push(obj2);
					}
				}
				break;
			}
			case Type.GlobalList:
			{
				if (m_GlobalList == null)
				{
					break;
				}
				m_GlobalList.Clear();
				object[] array = values;
				foreach (object obj in array)
				{
					if (obj != null)
					{
						m_GlobalList.Push(obj);
					}
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public void Clear(Args args)
		{
			switch (m_ListVariable)
			{
			case Type.LocalList:
			{
				LocalListVariables localListVariables = m_LocalList.Get<LocalListVariables>(args);
				if (!(localListVariables == null))
				{
					localListVariables.Clear();
				}
				break;
			}
			case Type.GlobalList:
				if (!(m_GlobalList == null))
				{
					m_GlobalList.Clear();
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public void Remove(IListGetPick pick, Args args)
		{
			switch (m_ListVariable)
			{
			case Type.LocalList:
			{
				LocalListVariables localListVariables = m_LocalList.Get<LocalListVariables>(args);
				if (!(localListVariables == null))
				{
					localListVariables.Remove(pick, args);
				}
				break;
			}
			case Type.GlobalList:
				if (!(m_GlobalList == null))
				{
					m_GlobalList.Remove(pick, args);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public override string ToString()
		{
			return m_ListVariable switch
			{
				Type.LocalList => m_LocalList.ToString(), 
				Type.GlobalList => (m_GlobalList != null) ? m_GlobalList.name : "(none)", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}

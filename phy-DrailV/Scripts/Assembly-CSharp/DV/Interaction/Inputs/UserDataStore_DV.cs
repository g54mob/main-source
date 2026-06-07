using System;
using System.IO;
using System.Text;
using DV.UserManagement;
using DV.UserManagement.Storage;
using DV.Utils;
using Rewired.Data;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	public class UserDataStore_DV : UserDataStore_File, UserDataStore_File.IDataHandler
	{
		private IStorageProvider Storage
		{
			get
			{
				if (SingletonBehaviour<UserManager>.Instance == null)
				{
					return null;
				}
				if (SingletonBehaviour<UserManager>.Instance.CurrentUser == null)
				{
					return null;
				}
				return SingletonBehaviour<UserManager>.Instance.CurrentUser.Storage;
			}
		}

		protected override void SetInitialValues()
		{
			base.SetInitialValues();
			base.directory = SingletonBehaviour<UserManager>.Instance?.CurrentUser?.UserBasePath;
			base.dataHandler = this;
		}

		private void Start()
		{
			if ((bool)SingletonBehaviour<UserManager>.Instance)
			{
				SingletonBehaviour<UserManager>.Instance.UserChanged += delegate
				{
					OnInitialize();
				};
			}
			OnInitialize();
		}

		public override void Load()
		{
			base.Load();
			InputManager.Fire_KeybindingsChanged();
		}

		bool IDataHandler.Load(string absoluteFilePath, out string data)
		{
			data = null;
			if (string.IsNullOrEmpty(absoluteFilePath))
			{
				return false;
			}
			if (Storage == null)
			{
				return false;
			}
			if (!Storage.FileExists(absoluteFilePath))
			{
				return false;
			}
			try
			{
				switch (base.dataFormat)
				{
				case DataFormat.Binary:
					data = Encoding.UTF8.GetString(Storage.ReadFileToBytes(absoluteFilePath));
					break;
				case DataFormat.Text:
					data = Storage.ReadFileToString(absoluteFilePath);
					break;
				default:
					throw new NotImplementedException();
				}
				return !string.IsNullOrEmpty(data);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				return false;
			}
		}

		bool IDataHandler.Save(string absoluteFilePath, string data)
		{
			if (string.IsNullOrEmpty(absoluteFilePath))
			{
				return false;
			}
			if (Storage == null)
			{
				return false;
			}
			try
			{
				if (!Storage.DirectoryExists(Path.GetDirectoryName(absoluteFilePath)))
				{
					Storage.CreateDirectory(Path.GetDirectoryName(absoluteFilePath));
				}
				switch (base.dataFormat)
				{
				case DataFormat.Binary:
					Storage.WriteFile(absoluteFilePath, Encoding.UTF8.GetBytes(data));
					Debug.Log("Wrote file: " + absoluteFilePath);
					return true;
				case DataFormat.Text:
					Storage.WriteFile(absoluteFilePath, data);
					Debug.Log("Wrote file: " + absoluteFilePath);
					return true;
				default:
					throw new NotImplementedException();
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				return false;
			}
		}

		bool IDataHandler.Clear(string absoluteFilePath)
		{
			if (string.IsNullOrEmpty(absoluteFilePath))
			{
				return false;
			}
			if (Storage == null)
			{
				return false;
			}
			try
			{
				if (Storage.FileExists(absoluteFilePath))
				{
					Storage.DeleteFile(absoluteFilePath);
					return true;
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return false;
		}
	}
}

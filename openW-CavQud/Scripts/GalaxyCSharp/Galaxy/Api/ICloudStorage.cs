using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class ICloudStorage : IDisposable
	{
		public enum ReadPhase
		{
			CHECKSUM_CALCULATING = 0,
			UPLOADING = 1
		}

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public static readonly uint MIN_HASH_BUFFER_SIZE = GalaxyInstancePINVOKE.ICloudStorage_MIN_HASH_BUFFER_SIZE_get();

		internal ICloudStorage(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(ICloudStorage obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ICloudStorage()
		{
			Dispose();
		}

		public virtual void Dispose()
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						GalaxyInstancePINVOKE.delete_ICloudStorage(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public virtual void GetFileList(string container, ICloudStorageGetFileListListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_GetFileList(swigCPtr, container, ICloudStorageGetFileListListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual string GetFileNameByIndex(uint index)
		{
			string result = GalaxyInstancePINVOKE.ICloudStorage_GetFileNameByIndex(swigCPtr, index);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual uint GetFileSizeByIndex(uint index)
		{
			uint result = GalaxyInstancePINVOKE.ICloudStorage_GetFileSizeByIndex(swigCPtr, index);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual uint GetFileTimestampByIndex(uint index)
		{
			uint result = GalaxyInstancePINVOKE.ICloudStorage_GetFileTimestampByIndex(swigCPtr, index);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual string GetFileHashByIndex(uint index)
		{
			string result = GalaxyInstancePINVOKE.ICloudStorage_GetFileHashByIndex(swigCPtr, index);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual void GetFile(string container, string name, IntPtr userParam, SWIGTYPE_p_f_p_void_p_q_const__char_int__int writeFunc, ICloudStorageGetFileListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_GetFile__SWIG_0(swigCPtr, container, name, userParam, SWIGTYPE_p_f_p_void_p_q_const__char_int__int.getCPtr(writeFunc), ICloudStorageGetFileListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void GetFile(string container, string name, byte[] dataBuffer, uint bufferLength, ICloudStorageGetFileListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_GetFile__SWIG_1(swigCPtr, container, name, dataBuffer, bufferLength, ICloudStorageGetFileListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void GetFileMetadata(string container, string name, ICloudStorageGetFileListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_GetFileMetadata(swigCPtr, container, name, ICloudStorageGetFileListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, IntPtr userParam, SWIGTYPE_p_f_p_void_p_char_int__int readFunc, SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int rewindFunc, ICloudStoragePutFileListener listener, SavegameType savegameType, uint timeStamp, string hash)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_0(swigCPtr, container, name, userParam, SWIGTYPE_p_f_p_void_p_char_int__int.getCPtr(readFunc), SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int.getCPtr(rewindFunc), ICloudStoragePutFileListener.getCPtr(listener), (int)savegameType, timeStamp, hash);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, IntPtr userParam, SWIGTYPE_p_f_p_void_p_char_int__int readFunc, SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int rewindFunc, ICloudStoragePutFileListener listener, SavegameType savegameType, uint timeStamp)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_1(swigCPtr, container, name, userParam, SWIGTYPE_p_f_p_void_p_char_int__int.getCPtr(readFunc), SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int.getCPtr(rewindFunc), ICloudStoragePutFileListener.getCPtr(listener), (int)savegameType, timeStamp);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, IntPtr userParam, SWIGTYPE_p_f_p_void_p_char_int__int readFunc, SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int rewindFunc, ICloudStoragePutFileListener listener, SavegameType savegameType)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_2(swigCPtr, container, name, userParam, SWIGTYPE_p_f_p_void_p_char_int__int.getCPtr(readFunc), SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int.getCPtr(rewindFunc), ICloudStoragePutFileListener.getCPtr(listener), (int)savegameType);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, IntPtr userParam, SWIGTYPE_p_f_p_void_p_char_int__int readFunc, SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int rewindFunc, ICloudStoragePutFileListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_3(swigCPtr, container, name, userParam, SWIGTYPE_p_f_p_void_p_char_int__int.getCPtr(readFunc), SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int.getCPtr(rewindFunc), ICloudStoragePutFileListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, byte[] buffer, uint bufferLength, ICloudStoragePutFileListener listener, SavegameType savegameType, uint timeStamp, string hash)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_4(swigCPtr, container, name, buffer, bufferLength, ICloudStoragePutFileListener.getCPtr(listener), (int)savegameType, timeStamp, hash);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, byte[] buffer, uint bufferLength, ICloudStoragePutFileListener listener, SavegameType savegameType, uint timeStamp)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_5(swigCPtr, container, name, buffer, bufferLength, ICloudStoragePutFileListener.getCPtr(listener), (int)savegameType, timeStamp);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, byte[] buffer, uint bufferLength, ICloudStoragePutFileListener listener, SavegameType savegameType)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_6(swigCPtr, container, name, buffer, bufferLength, ICloudStoragePutFileListener.getCPtr(listener), (int)savegameType);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void PutFile(string container, string name, byte[] buffer, uint bufferLength, ICloudStoragePutFileListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_PutFile__SWIG_7(swigCPtr, container, name, buffer, bufferLength, ICloudStoragePutFileListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void CalculateHash(IntPtr userParam, SWIGTYPE_p_f_p_void_p_char_int__int readFunc, SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int rewindFunc, ref byte[] hashBuffer, uint hashBufferSize)
		{
			GalaxyInstancePINVOKE.ICloudStorage_CalculateHash__SWIG_0(swigCPtr, userParam, SWIGTYPE_p_f_p_void_p_char_int__int.getCPtr(readFunc), SWIGTYPE_p_f_p_void_enum_galaxy__api__ICloudStorage__ReadPhase__int.getCPtr(rewindFunc), hashBuffer, hashBufferSize);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void CalculateHash(byte[] buffer, uint bufferLength, ref byte[] hashBuffer, uint hashBufferSize)
		{
			GalaxyInstancePINVOKE.ICloudStorage_CalculateHash__SWIG_1(swigCPtr, buffer, bufferLength, hashBuffer, hashBufferSize);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void DeleteFile(string container, string name, ICloudStorageDeleteFileListener listener, string expectedHash)
		{
			GalaxyInstancePINVOKE.ICloudStorage_DeleteFile__SWIG_0(swigCPtr, container, name, ICloudStorageDeleteFileListener.getCPtr(listener), expectedHash);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void DeleteFile(string container, string name, ICloudStorageDeleteFileListener listener)
		{
			GalaxyInstancePINVOKE.ICloudStorage_DeleteFile__SWIG_1(swigCPtr, container, name, ICloudStorageDeleteFileListener.getCPtr(listener));
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void OpenSavegame()
		{
			GalaxyInstancePINVOKE.ICloudStorage_OpenSavegame(swigCPtr);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void CloseSavegame()
		{
			GalaxyInstancePINVOKE.ICloudStorage_CloseSavegame(swigCPtr);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}
}

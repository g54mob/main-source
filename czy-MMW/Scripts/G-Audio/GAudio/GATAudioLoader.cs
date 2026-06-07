using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

namespace GAudio
{
	public class GATAudioLoader
	{
		private struct ProgressInfo
		{
			public readonly float progress;

			public readonly GATData[] data;

			public readonly string fileName;

			public bool IsFileProgress => data == null;

			public ProgressInfo(float iprogress, string filename)
			{
				data = null;
				progress = iprogress;
				fileName = filename;
			}

			public ProgressInfo(GATData[] channelData, string filename)
			{
				progress = 1f;
				data = channelData;
				fileName = filename;
			}
		}

		private class LoadingOperation : AGATLoadingOperation
		{
			private Queue<string> _paths;

			private GATDataAllocationMode _allocationMode;

			private bool _forceMono;

			private bool _reportsProgress;

			public LoadingOperation(GATDataAllocationMode allocationMode, int numFiles, FileLoadedHandler handler, bool forceMono = false)
			{
				_allocationMode = allocationMode;
				_paths = new Queue<string>(numFiles);
				base.Status = LoadOperationStatus.Configuring;
				base.OnFileWasLoaded = handler;
				_forceMono = forceMono;
			}

			public void SetStatus(LoadOperationStatus status)
			{
				base.Status = status;
			}

			public override bool AddFile(string relativePath, PathRelativeType pathType)
			{
				if (base.Status != LoadOperationStatus.Configuring)
				{
					return false;
				}
				string text = Path.GetExtension(relativePath).ToLower();
				if (text != ".wav" && text != ".ogg")
				{
					return false;
				}
				string absolutePath = GATPathsHelper.GetAbsolutePath(relativePath, pathType, createDirectory: false);
				if (!File.Exists(absolutePath))
				{
					return false;
				}
				_paths.Enqueue(absolutePath);
				return true;
			}

			public void OperationWillStart()
			{
				base.Status = LoadOperationStatus.Loading;
				_reportsProgress = base.OnFileLoadProgress != null;
			}

			public GATData[] LoadNext(BackgroundWorker worker, float[] deInterleaveBuffer)
			{
				if (_paths.Count == 0)
				{
					base.Status = LoadOperationStatus.Done;
					return null;
				}
				AGATAudioFile aGATAudioFile;
				try
				{
					aGATAudioFile = AGATAudioFile.OpenAudioFileAtPath(_paths.Dequeue());
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					base.FailReason = LoadOperationFailReason.CannotOpenFile;
					base.Status = LoadOperationStatus.Failed;
					return null;
				}
				GATData[] array;
				using (aGATAudioFile)
				{
					int channels = aGATAudioFile.Channels;
					base.CurrentFileName = aGATAudioFile.FileName;
					array = ((_forceMono || channels <= 1) ? new GATData[1] : new GATData[channels]);
					for (int i = 0; i < array.Length; i++)
					{
						if (_allocationMode == GATDataAllocationMode.Fixed)
						{
							try
							{
								array[i] = GATManager.GetFixedDataContainer(aGATAudioFile.NumFrames, aGATAudioFile.FileName);
							}
							catch (Exception exception2)
							{
								ReleaseContainers(array);
								base.Status = LoadOperationStatus.Failed;
								base.FailReason = LoadOperationFailReason.OutOfPreAllocatedMemory;
								Debug.LogException(exception2);
								return null;
							}
						}
						else if (_allocationMode == GATDataAllocationMode.Managed)
						{
							try
							{
								array[i] = GATManager.GetDataContainer(aGATAudioFile.NumFrames);
							}
							catch (Exception exception3)
							{
								ReleaseContainers(array);
								base.Status = LoadOperationStatus.Failed;
								base.FailReason = LoadOperationFailReason.NoLargeEnoughChunkInAllocator;
								Debug.LogException(exception3);
								return null;
							}
						}
						else
						{
							array[i] = new GATData(new float[aGATAudioFile.NumFrames]);
						}
					}
					int num = 0;
					if (channels > 1)
					{
						int num2 = deInterleaveBuffer.Length / channels;
						int num3;
						do
						{
							if (worker.CancellationPending)
							{
								ReleaseContainers(array);
								return null;
							}
							num3 = aGATAudioFile.ReadNextChunk(deInterleaveBuffer, 0, num2);
							if (_forceMono)
							{
								int num4 = num3 * channels;
								for (int i = 0; i < num4; i += channels)
								{
									deInterleaveBuffer[i] += deInterleaveBuffer[i + 1];
								}
								array[0].CopyFromInterlaced(deInterleaveBuffer, num3, num, 0, channels);
							}
							else
							{
								for (int i = 0; i < channels; i++)
								{
									array[i].CopyFromInterlaced(deInterleaveBuffer, num3, num, i, channels);
								}
							}
							num += num3;
							if (_reportsProgress)
							{
								worker.ReportProgress(0, new ProgressInfo((float)num / (float)aGATAudioFile.NumFrames, aGATAudioFile.FileName));
							}
						}
						while (num3 >= num2);
					}
					else
					{
						while (num < aGATAudioFile.NumFrames)
						{
							if (worker.CancellationPending)
							{
								ReleaseContainers(array);
								return null;
							}
							int num5 = aGATAudioFile.NumFrames - num;
							int num2 = ((num5 < 16384) ? num5 : 16384);
							int num3 = aGATAudioFile.ReadNextChunk(array[0].ParentArray, array[0].MemOffset + num, num2);
							num += num3;
							if (_reportsProgress)
							{
								worker.ReportProgress(0, new ProgressInfo((float)num / (float)aGATAudioFile.NumFrames, aGATAudioFile.FileName));
							}
						}
					}
				}
				return array;
			}

			private void ReleaseContainers(GATData[] containers)
			{
				if (containers == null)
				{
					return;
				}
				for (int i = 0; i < containers.Length; i++)
				{
					if (containers[i] != null)
					{
						containers[i].Release();
					}
				}
			}
		}

		private BackgroundWorker _bw;

		private LoadingOperation _currentOperation;

		private Queue<LoadingOperation> _pendingOperations = new Queue<LoadingOperation>();

		private float[] _buffer;

		private static GATAudioLoader __sharedInstance;

		public static GATAudioLoader SharedInstance
		{
			get
			{
				if (__sharedInstance == null)
				{
					return new GATAudioLoader();
				}
				return __sharedInstance;
			}
		}

		public void LoadFilesToSampleBank(string[] filePaths, PathRelativeType pathType, GATSampleBank targetBank, GATDataAllocationMode allocationMode, OperationCompletedHandler onOperationCompleted, bool forceMono = false)
		{
			AGATLoadingOperation aGATLoadingOperation = new LoadingOperation(allocationMode, filePaths.Length, targetBank.AddLoadedFile, forceMono);
			for (int i = 0; i < filePaths.Length; i++)
			{
				aGATLoadingOperation.AddFile(filePaths[i], pathType);
			}
			aGATLoadingOperation.OnOperationCompleted = onOperationCompleted;
			EnqueueOperation(aGATLoadingOperation);
		}

		public void LoadFolderToSampleBank(string folderPath, PathRelativeType pathType, GATSampleBank targetBank, GATDataAllocationMode allocationMode, OperationCompletedHandler onOperationCompleted, bool forceMono = false)
		{
			folderPath = GATPathsHelper.GetAbsolutePath(folderPath, pathType, createDirectory: false);
			if (!Directory.Exists(folderPath))
			{
				throw new GATException("No such directory!");
			}
			string[] files = Directory.GetFiles(folderPath);
			if (files.Length != 0)
			{
				LoadFilesToSampleBank(files, PathRelativeType.Absolute, targetBank, allocationMode, onOperationCompleted, forceMono);
			}
		}

		public void CancelPendingOperations()
		{
			if (_bw != null)
			{
				_pendingOperations.Clear();
				_bw.CancelAsync();
			}
		}

		public AGATLoadingOperation NewOperation(int numFilesToLoad, GATDataAllocationMode allocationMode, FileLoadedHandler onFileWasLoaded, bool forceMono = false)
		{
			return new LoadingOperation(allocationMode, numFilesToLoad, onFileWasLoaded, forceMono);
		}

		public void EnqueueOperation(AGATLoadingOperation operation)
		{
			if (_bw == null)
			{
				SetupWorker();
				_currentOperation = (LoadingOperation)operation;
				_currentOperation.OperationWillStart();
				_bw.RunWorkerAsync(_currentOperation);
			}
			else
			{
				_pendingOperations.Enqueue((LoadingOperation)operation);
			}
		}

		private GATAudioLoader()
		{
			_buffer = new float[16384 * GATInfo.MaxIOChannels];
			__sharedInstance = this;
		}

		private void SetupWorker()
		{
			_bw = new BackgroundWorker();
			_bw.WorkerSupportsCancellation = true;
			_bw.WorkerReportsProgress = true;
			_bw.DoWork += bw_Work;
			_bw.RunWorkerCompleted += bw_Completed;
			_bw.ProgressChanged += bw_Progress;
		}

		private void bw_Work(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			if (backgroundWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			LoadingOperation loadingOperation = e.Argument as LoadingOperation;
			while (true)
			{
				GATData[] array = loadingOperation.LoadNext(backgroundWorker, _buffer);
				if (array == null)
				{
					break;
				}
				backgroundWorker.ReportProgress(0, new ProgressInfo(array, loadingOperation.CurrentFileName));
			}
			if (loadingOperation.Status == LoadOperationStatus.Cancelled)
			{
				e.Cancel = true;
			}
		}

		private void bw_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				_currentOperation.SetStatus(LoadOperationStatus.Failed);
			}
			else if (e.Cancelled)
			{
				_currentOperation.SetStatus(LoadOperationStatus.Cancelled);
				_pendingOperations.Clear();
			}
			if (_currentOperation.OnOperationCompleted != null)
			{
				_currentOperation.OnOperationCompleted(_currentOperation);
			}
			if (_pendingOperations.Count > 0)
			{
				_currentOperation = _pendingOperations.Dequeue();
				_currentOperation.OperationWillStart();
				_bw.RunWorkerAsync(_currentOperation);
			}
			else
			{
				_bw = null;
				_currentOperation = null;
			}
		}

		private void bw_Progress(object sender, ProgressChangedEventArgs e)
		{
			ProgressInfo progressInfo = (ProgressInfo)e.UserState;
			if (progressInfo.IsFileProgress)
			{
				if (_currentOperation.OnFileLoadProgress != null)
				{
					_currentOperation.OnFileLoadProgress(progressInfo.progress, progressInfo.fileName);
				}
			}
			else if (_currentOperation.OnFileWasLoaded != null)
			{
				_currentOperation.OnFileWasLoaded(progressInfo.data, progressInfo.fileName);
			}
		}

		public GATData[] LoadSync(AGATAudioFile file, GATDataAllocationMode allocationMode)
		{
			bool flag = false;
			GATData[] array = new GATData[file.Channels];
			for (int i = 0; i < file.Channels; i++)
			{
				switch (allocationMode)
				{
				case GATDataAllocationMode.Fixed:
					try
					{
						array[i] = GATManager.GetFixedDataContainer(file.NumFrames, file.FileName);
					}
					catch (Exception exception2)
					{
						flag = true;
						Debug.LogException(exception2);
					}
					break;
				case GATDataAllocationMode.Managed:
					try
					{
						array[i] = GATManager.GetDataContainer(file.NumFrames);
					}
					catch (Exception exception)
					{
						flag = true;
						Debug.LogException(exception);
					}
					break;
				default:
					array[i] = new GATData(new float[file.NumFrames]);
					break;
				}
			}
			if (flag)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null)
					{
						array[i].Release();
					}
				}
				return null;
			}
			if (file.Channels == 1)
			{
				file.ReadNextChunk(array[0].ParentArray, array[0].MemOffset, file.NumFrames);
				return array;
			}
			int num = 0;
			int num2 = _buffer.Length / file.Channels;
			int num3;
			do
			{
				num3 = file.ReadNextChunk(_buffer, 0, num2);
				for (int i = 0; i < file.Channels; i++)
				{
					array[i].CopyFromInterlaced(_buffer, num3, num, i, file.Channels);
				}
				num += num3;
			}
			while (num3 >= num2);
			return array;
		}
	}
}

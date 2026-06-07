using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Rewired.Utils.Classes.Data
{
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal struct Entry
		{
			public int hashCode;

			public int next;

			public TKey key;

			public TValue value;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
		{
			private ADictionary<TKey, TValue> JpMsdhMhEvdVPsdcclmmIeBOOABX;

			private int IDzUbehSQcESAihhnKSwaJcuIIiEb;

			private int EeYchPFbNhguaKOpExUxgGDvUoQn;

			private KeyValuePair<TKey, TValue> NSTByxaRsGMEyDCajjrcElorLfGK;

			private int CjbSGENJAyBwzdWiyzdowgoHtfhQ;

			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => NSTByxaRsGMEyDCajjrcElorLfGK;

			object IEnumerator.Current
			{
				get
				{
					if (EeYchPFbNhguaKOpExUxgGDvUoQn == 0 || EeYchPFbNhguaKOpExUxgGDvUoQn == JpMsdhMhEvdVPsdcclmmIeBOOABX._count + 1)
					{
						throw new Exception();
					}
					if (CjbSGENJAyBwzdWiyzdowgoHtfhQ == 1)
					{
						return new DictionaryEntry(NSTByxaRsGMEyDCajjrcElorLfGK.Key, NSTByxaRsGMEyDCajjrcElorLfGK.Value);
					}
					return new KeyValuePair<TKey, TValue>(NSTByxaRsGMEyDCajjrcElorLfGK.Key, NSTByxaRsGMEyDCajjrcElorLfGK.Value);
				}
			}

			DictionaryEntry IDictionaryEnumerator.Entry
			{
				get
				{
					if (EeYchPFbNhguaKOpExUxgGDvUoQn == 0 || EeYchPFbNhguaKOpExUxgGDvUoQn == JpMsdhMhEvdVPsdcclmmIeBOOABX._count + 1)
					{
						throw new Exception();
					}
					return new DictionaryEntry(NSTByxaRsGMEyDCajjrcElorLfGK.Key, NSTByxaRsGMEyDCajjrcElorLfGK.Value);
				}
			}

			object IDictionaryEnumerator.Key
			{
				get
				{
					if (EeYchPFbNhguaKOpExUxgGDvUoQn == 0 || EeYchPFbNhguaKOpExUxgGDvUoQn == JpMsdhMhEvdVPsdcclmmIeBOOABX._count + 1)
					{
						throw new Exception();
					}
					return NSTByxaRsGMEyDCajjrcElorLfGK.Key;
				}
			}

			object IDictionaryEnumerator.Value
			{
				get
				{
					if (EeYchPFbNhguaKOpExUxgGDvUoQn == 0 || EeYchPFbNhguaKOpExUxgGDvUoQn == JpMsdhMhEvdVPsdcclmmIeBOOABX._count + 1)
					{
						throw new Exception();
					}
					return NSTByxaRsGMEyDCajjrcElorLfGK.Value;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
			{
				JpMsdhMhEvdVPsdcclmmIeBOOABX = P_0;
				IDzUbehSQcESAihhnKSwaJcuIIiEb = P_0.sdSuPKgRfwizkeBpxcpybNGIECcB;
				EeYchPFbNhguaKOpExUxgGDvUoQn = 0;
				CjbSGENJAyBwzdWiyzdowgoHtfhQ = P_1;
				NSTByxaRsGMEyDCajjrcElorLfGK = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				if (IDzUbehSQcESAihhnKSwaJcuIIiEb != JpMsdhMhEvdVPsdcclmmIeBOOABX.sdSuPKgRfwizkeBpxcpybNGIECcB)
				{
					throw new Exception();
				}
				while ((uint)EeYchPFbNhguaKOpExUxgGDvUoQn < (uint)JpMsdhMhEvdVPsdcclmmIeBOOABX._count)
				{
					if (JpMsdhMhEvdVPsdcclmmIeBOOABX._entries[EeYchPFbNhguaKOpExUxgGDvUoQn].hashCode >= 0)
					{
						NSTByxaRsGMEyDCajjrcElorLfGK = new KeyValuePair<TKey, TValue>(JpMsdhMhEvdVPsdcclmmIeBOOABX._entries[EeYchPFbNhguaKOpExUxgGDvUoQn].key, JpMsdhMhEvdVPsdcclmmIeBOOABX._entries[EeYchPFbNhguaKOpExUxgGDvUoQn].value);
						EeYchPFbNhguaKOpExUxgGDvUoQn++;
						return true;
					}
					EeYchPFbNhguaKOpExUxgGDvUoQn++;
				}
				EeYchPFbNhguaKOpExUxgGDvUoQn = JpMsdhMhEvdVPsdcclmmIeBOOABX._count + 1;
				NSTByxaRsGMEyDCajjrcElorLfGK = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			void IEnumerator.Reset()
			{
				if (IDzUbehSQcESAihhnKSwaJcuIIiEb != JpMsdhMhEvdVPsdcclmmIeBOOABX.sdSuPKgRfwizkeBpxcpybNGIECcB)
				{
					throw new Exception();
				}
				EeYchPFbNhguaKOpExUxgGDvUoQn = 0;
				NSTByxaRsGMEyDCajjrcElorLfGK = default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			[CustomObfuscation(rename = false)]
			public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> MgwmJVZPkFiarEodLHpDEAcgXkiwB;

				private int UQceouEvOveiaBXvczuTIFkMBjtwA;

				private int rmVdqHrzqxGxTByXCfMBJnPbtRDv;

				private TKey GCJmcmoGBWraFpbzpEAYHueXyYotA;

				TKey IEnumerator<TKey>.Current => GCJmcmoGBWraFpbzpEAYHueXyYotA;

				object IEnumerator.Current
				{
					get
					{
						if (UQceouEvOveiaBXvczuTIFkMBjtwA == 0 || UQceouEvOveiaBXvczuTIFkMBjtwA == MgwmJVZPkFiarEodLHpDEAcgXkiwB._count + 1)
						{
							throw new Exception();
						}
						return GCJmcmoGBWraFpbzpEAYHueXyYotA;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					MgwmJVZPkFiarEodLHpDEAcgXkiwB = P_0;
					rmVdqHrzqxGxTByXCfMBJnPbtRDv = P_0.sdSuPKgRfwizkeBpxcpybNGIECcB;
					UQceouEvOveiaBXvczuTIFkMBjtwA = 0;
					GCJmcmoGBWraFpbzpEAYHueXyYotA = default(TKey);
				}

				public void Dispose()
				{
				}

				void IDisposable.Dispose()
				{
					//ILSpy generated this explicit interface implementation from .override directive in Dispose
					this.Dispose();
				}

				public bool MoveNext()
				{
					if (rmVdqHrzqxGxTByXCfMBJnPbtRDv != MgwmJVZPkFiarEodLHpDEAcgXkiwB.sdSuPKgRfwizkeBpxcpybNGIECcB)
					{
						throw new Exception();
					}
					while ((uint)UQceouEvOveiaBXvczuTIFkMBjtwA < (uint)MgwmJVZPkFiarEodLHpDEAcgXkiwB._count)
					{
						if (MgwmJVZPkFiarEodLHpDEAcgXkiwB._entries[UQceouEvOveiaBXvczuTIFkMBjtwA].hashCode >= 0)
						{
							GCJmcmoGBWraFpbzpEAYHueXyYotA = MgwmJVZPkFiarEodLHpDEAcgXkiwB._entries[UQceouEvOveiaBXvczuTIFkMBjtwA].key;
							UQceouEvOveiaBXvczuTIFkMBjtwA++;
							return true;
						}
						UQceouEvOveiaBXvczuTIFkMBjtwA++;
					}
					UQceouEvOveiaBXvczuTIFkMBjtwA = MgwmJVZPkFiarEodLHpDEAcgXkiwB._count + 1;
					GCJmcmoGBWraFpbzpEAYHueXyYotA = default(TKey);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (rmVdqHrzqxGxTByXCfMBJnPbtRDv != MgwmJVZPkFiarEodLHpDEAcgXkiwB.sdSuPKgRfwizkeBpxcpybNGIECcB)
					{
						throw new Exception();
					}
					UQceouEvOveiaBXvczuTIFkMBjtwA = 0;
					GCJmcmoGBWraFpbzpEAYHueXyYotA = default(TKey);
				}
			}

			private ADictionary<TKey, TValue> xLIeTSDQdACulaueRieaYFvwYXZH;

			int ICollection<TKey>.Count => xLIeTSDQdACulaueRieaYFvwYXZH.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)xLIeTSDQdACulaueRieaYFvwYXZH).SyncRoot;

			public KeyCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				xLIeTSDQdACulaueRieaYFvwYXZH = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(xLIeTSDQdACulaueRieaYFvwYXZH);
			}

			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (array.Length - index < xLIeTSDQdACulaueRieaYFvwYXZH.Count)
				{
					throw new Exception();
				}
				int count = xLIeTSDQdACulaueRieaYFvwYXZH._count;
				Entry[] entries = xLIeTSDQdACulaueRieaYFvwYXZH._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			void ICollection<TKey>.CopyTo(TKey[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void bjJXRoSDiVBPVKAUSBJzKoSmiYRy(TKey P_0)
			{
				throw new Exception();
			}

			void ICollection<TKey>.Add(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in bjJXRoSDiVBPVKAUSBJzKoSmiYRy
				this.bjJXRoSDiVBPVKAUSBJzKoSmiYRy(P_0);
			}

			private void iOQCvXKazrRocjdKsQfNUlusTifw()
			{
				throw new Exception();
			}

			void ICollection<TKey>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in iOQCvXKazrRocjdKsQfNUlusTifw
				this.iOQCvXKazrRocjdKsQfNUlusTifw();
			}

			private bool gOkHAtiOAPSwPsQZHFYazvfQpyFR(TKey P_0)
			{
				return xLIeTSDQdACulaueRieaYFvwYXZH.ContainsKey(P_0);
			}

			bool ICollection<TKey>.Contains(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in gOkHAtiOAPSwPsQZHFYazvfQpyFR
				return this.gOkHAtiOAPSwPsQZHFYazvfQpyFR(P_0);
			}

			private bool dAdIstvrjrLWRaBkCWzibTmIDPBV(TKey P_0)
			{
				throw new Exception();
			}

			bool ICollection<TKey>.Remove(TKey P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in dAdIstvrjrLWRaBkCWzibTmIDPBV
				return this.dAdIstvrjrLWRaBkCWzibTmIDPBV(P_0);
			}

			private IEnumerator<TKey> ABKnyctOjQOMmNgDTaROSpbUuEKm()
			{
				return new Enumerator(xLIeTSDQdACulaueRieaYFvwYXZH);
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ABKnyctOjQOMmNgDTaROSpbUuEKm
				return this.ABKnyctOjQOMmNgDTaROSpbUuEKm();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(xLIeTSDQdACulaueRieaYFvwYXZH);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < xLIeTSDQdACulaueRieaYFvwYXZH.Count)
				{
					throw new Exception();
				}
				if (array is TKey[] array2)
				{
					CopyTo(array2, index);
					return;
				}
				if (!(array is object[] array3))
				{
					throw new Exception();
				}
				int count = xLIeTSDQdACulaueRieaYFvwYXZH._count;
				Entry[] entries = xLIeTSDQdACulaueRieaYFvwYXZH._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].key;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private ADictionary<TKey, TValue> REkuwhHbxpxJVsFmqvzTgJeQzfzc;

				private int EZtWVhLoeFcQOirRYcamAGkCyPZub;

				private int llkGpVjuPOfNYRLvcEVUljeVgCjR;

				private TValue bDeOgCGAGgrcgtEbsAksjrdGflvAb;

				TValue IEnumerator<TValue>.Current => bDeOgCGAGgrcgtEbsAksjrdGflvAb;

				object IEnumerator.Current
				{
					get
					{
						if (EZtWVhLoeFcQOirRYcamAGkCyPZub == 0 || EZtWVhLoeFcQOirRYcamAGkCyPZub == REkuwhHbxpxJVsFmqvzTgJeQzfzc._count + 1)
						{
							throw new Exception();
						}
						return bDeOgCGAGgrcgtEbsAksjrdGflvAb;
					}
				}

				internal Enumerator(ADictionary<TKey, TValue> P_0)
				{
					REkuwhHbxpxJVsFmqvzTgJeQzfzc = P_0;
					llkGpVjuPOfNYRLvcEVUljeVgCjR = P_0.sdSuPKgRfwizkeBpxcpybNGIECcB;
					EZtWVhLoeFcQOirRYcamAGkCyPZub = 0;
					bDeOgCGAGgrcgtEbsAksjrdGflvAb = default(TValue);
				}

				public void Dispose()
				{
				}

				void IDisposable.Dispose()
				{
					//ILSpy generated this explicit interface implementation from .override directive in Dispose
					this.Dispose();
				}

				public bool MoveNext()
				{
					if (llkGpVjuPOfNYRLvcEVUljeVgCjR != REkuwhHbxpxJVsFmqvzTgJeQzfzc.sdSuPKgRfwizkeBpxcpybNGIECcB)
					{
						throw new Exception();
					}
					while ((uint)EZtWVhLoeFcQOirRYcamAGkCyPZub < (uint)REkuwhHbxpxJVsFmqvzTgJeQzfzc._count)
					{
						if (REkuwhHbxpxJVsFmqvzTgJeQzfzc._entries[EZtWVhLoeFcQOirRYcamAGkCyPZub].hashCode >= 0)
						{
							bDeOgCGAGgrcgtEbsAksjrdGflvAb = REkuwhHbxpxJVsFmqvzTgJeQzfzc._entries[EZtWVhLoeFcQOirRYcamAGkCyPZub].value;
							EZtWVhLoeFcQOirRYcamAGkCyPZub++;
							return true;
						}
						EZtWVhLoeFcQOirRYcamAGkCyPZub++;
					}
					EZtWVhLoeFcQOirRYcamAGkCyPZub = REkuwhHbxpxJVsFmqvzTgJeQzfzc._count + 1;
					bDeOgCGAGgrcgtEbsAksjrdGflvAb = default(TValue);
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				void IEnumerator.Reset()
				{
					if (llkGpVjuPOfNYRLvcEVUljeVgCjR != REkuwhHbxpxJVsFmqvzTgJeQzfzc.sdSuPKgRfwizkeBpxcpybNGIECcB)
					{
						throw new Exception();
					}
					EZtWVhLoeFcQOirRYcamAGkCyPZub = 0;
					bDeOgCGAGgrcgtEbsAksjrdGflvAb = default(TValue);
				}
			}

			private ADictionary<TKey, TValue> mRiAsCKGpmApEBFzdnDGOCexHzJJb;

			int ICollection<TValue>.Count => mRiAsCKGpmApEBFzdnDGOCexHzJJb.Count;

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)mRiAsCKGpmApEBFzdnDGOCexHzJJb).SyncRoot;

			public ValueCollection(ADictionary<TKey, TValue> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				mRiAsCKGpmApEBFzdnDGOCexHzJJb = P_0;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(mRiAsCKGpmApEBFzdnDGOCexHzJJb);
			}

			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < mRiAsCKGpmApEBFzdnDGOCexHzJJb.Count)
				{
					throw new Exception();
				}
				int count = mRiAsCKGpmApEBFzdnDGOCexHzJJb._count;
				Entry[] entries = mRiAsCKGpmApEBFzdnDGOCexHzJJb._entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			void ICollection<TValue>.CopyTo(TValue[] array, int index)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CopyTo
				this.CopyTo(array, index);
			}

			private void DTFnrGxqijnGYOMrLgWtaaTzEeULA(TValue P_0)
			{
				throw new Exception();
			}

			void ICollection<TValue>.Add(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in DTFnrGxqijnGYOMrLgWtaaTzEeULA
				this.DTFnrGxqijnGYOMrLgWtaaTzEeULA(P_0);
			}

			private bool AurcGeiegKcTbeqQkmszJyadkcTbB(TValue P_0)
			{
				throw new Exception();
			}

			bool ICollection<TValue>.Remove(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in AurcGeiegKcTbeqQkmszJyadkcTbB
				return this.AurcGeiegKcTbeqQkmszJyadkcTbB(P_0);
			}

			private void sbJktclsTXvSLHLDOFSaCxeMEPckA()
			{
				throw new Exception();
			}

			void ICollection<TValue>.Clear()
			{
				//ILSpy generated this explicit interface implementation from .override directive in sbJktclsTXvSLHLDOFSaCxeMEPckA
				this.sbJktclsTXvSLHLDOFSaCxeMEPckA();
			}

			private bool MyffLPPuJajMjAdyQATyamkdbprWB(TValue P_0)
			{
				return mRiAsCKGpmApEBFzdnDGOCexHzJJb.ContainsValue(P_0);
			}

			bool ICollection<TValue>.Contains(TValue P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in MyffLPPuJajMjAdyQATyamkdbprWB
				return this.MyffLPPuJajMjAdyQATyamkdbprWB(P_0);
			}

			private IEnumerator<TValue> MZBQBuiDcUPQPEBYrXKENltHtvOn()
			{
				return new Enumerator(mRiAsCKGpmApEBFzdnDGOCexHzJJb);
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MZBQBuiDcUPQPEBYrXKENltHtvOn
				return this.MZBQBuiDcUPQPEBYrXKENltHtvOn();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Enumerator(mRiAsCKGpmApEBFzdnDGOCexHzJJb);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (array.Rank != 1)
				{
					throw new Exception();
				}
				if (array.GetLowerBound(0) != 0)
				{
					throw new Exception();
				}
				if (index < 0 || index > array.Length)
				{
					throw new Exception();
				}
				if (array.Length - index < mRiAsCKGpmApEBFzdnDGOCexHzJJb.Count)
				{
					throw new Exception();
				}
				if (array is TValue[] array2)
				{
					CopyTo(array2, index);
					return;
				}
				if (!(array is object[] array3))
				{
					throw new Exception();
				}
				int count = mRiAsCKGpmApEBFzdnDGOCexHzJJb._count;
				Entry[] entries = mRiAsCKGpmApEBFzdnDGOCexHzJJb._entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].value;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					throw new Exception();
				}
			}
		}

		private int[] aOOsDqWvTQdfaiYnwFDOMasiFYpFA;

		internal Entry[] _entries;

		internal int _count;

		private int sdSuPKgRfwizkeBpxcpybNGIECcB;

		private int reTgoHUxMqcInLOEwACyilalphpw;

		private int dgkLSSnXpcQEwkBHeCZNfJwlJKDn;

		private int hXpSOFEqlPjPNoRtyqrLfhSHEFXEA;

		private IEqualityComparer<TKey> aKNDhLcGUfblLhDWqCfmlCZtDtzfb;

		private IEqualityComparer<TValue> IPYgDtTmMtXBkVklGxxtIYAxmGqc;

		private KeyCollection YopyFaLKwEQtpIhqbOHGvLiHBxkM;

		private ValueCollection FiwwafojyzNwnjcmXxhIEVKqhDeN;

		private readonly object ExYZKfrNhqjriKDysprVjdPPmRCcb = new object();

		private static readonly bool AwYlkpZPpQBHnIWhEsglUvfGDRgjA = ReflectionTools.IsValueType(typeof(TKey));

		private static readonly bool wXTpjNuOqABCYFtURMJpAYbsqrfv = ReflectionTools.IsValueType(typeof(TValue));

		private const string VdsfZMDFgQyEGLAdjPsMInToJlDSA = "Version";

		private const string LWHbdyiIbMkpNoKecicqvMBtngeK = "HashSize";

		private const string QikuaEmYAgVKDyGtoyWlEDsgDamHA = "KeyValuePairs";

		private const string aFjTiEXfCOKgcZQUCTFghigzHYHY = "Comparer";

		int ICollection<KeyValuePair<TKey, TValue>>.Count => _count - hXpSOFEqlPjPNoRtyqrLfhSHEFXEA;

		public int TotalCount => _count;

		public KeyCollection Keys
		{
			get
			{
				if (YopyFaLKwEQtpIhqbOHGvLiHBxkM == null)
				{
					YopyFaLKwEQtpIhqbOHGvLiHBxkM = new KeyCollection(this);
				}
				return YopyFaLKwEQtpIhqbOHGvLiHBxkM;
			}
		}

		public ValueCollection Values
		{
			get
			{
				if (FiwwafojyzNwnjcmXxhIEVKqhDeN == null)
				{
					FiwwafojyzNwnjcmXxhIEVKqhDeN = new ValueCollection(this);
				}
				return FiwwafojyzNwnjcmXxhIEVKqhDeN;
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return aKNDhLcGUfblLhDWqCfmlCZtDtzfb;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TKey>.Default;
				}
				aKNDhLcGUfblLhDWqCfmlCZtDtzfb = value;
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return IPYgDtTmMtXBkVklGxxtIYAxmGqc;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<TValue>.Default;
				}
				IPYgDtTmMtXBkVklGxxtIYAxmGqc = value;
			}
		}

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				int num = IndexOfKey(key);
				if (num < 0)
				{
					TKey val = key;
					throw new KeyNotFoundException("Key \"" + val?.ToString() + " does not exist.");
				}
				return _entries[num].value;
			}
			set
			{
				SIyZnALdbiVKJEAhaLvSDLjnWTBE(key, value, false);
			}
		}

		public int IndexOfFirst
		{
			get
			{
				for (int i = 0; i < _count; i++)
				{
					if (_entries[i].hashCode >= 0)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public int IndexOfLast
		{
			get
			{
				for (int num = _count - 1; num >= 0; num--)
				{
					if (_entries[num].hashCode >= 0)
					{
						return num;
					}
				}
				return -1;
			}
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				if (YopyFaLKwEQtpIhqbOHGvLiHBxkM == null)
				{
					YopyFaLKwEQtpIhqbOHGvLiHBxkM = new KeyCollection(this);
				}
				return YopyFaLKwEQtpIhqbOHGvLiHBxkM;
			}
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				if (FiwwafojyzNwnjcmXxhIEVKqhDeN == null)
				{
					FiwwafojyzNwnjcmXxhIEVKqhDeN = new ValueCollection(this);
				}
				return FiwwafojyzNwnjcmXxhIEVKqhDeN;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ExYZKfrNhqjriKDysprVjdPPmRCcb;

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => Keys;

		ICollection IDictionary.Values => Values;

		object IDictionary.this[object key]
		{
			get
			{
				if (cVGgglEnQkoBMyFDvFtjLDBYCqgcb(key))
				{
					int num = IndexOfKey((TKey)key);
					if (num >= 0)
					{
						return _entries[num].value;
					}
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				eMvMVauKSJQvntRixldOITcJzNMG<TValue>(value, "value");
				try
				{
					TKey val = (TKey)key;
					try
					{
						this[val] = (TValue)value;
					}
					catch (InvalidCastException)
					{
						throw new Exception();
					}
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
		}

		public ADictionary()
			: this(0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0)
			: this(0, P_0, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IEqualityComparer<TKey> P_0, IEqualityComparer<TValue> P_1)
			: this(0, P_0, P_1)
		{
		}

		public ADictionary(int P_0)
			: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1)
			: this(P_0, P_1, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(int P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
		{
			if (P_0 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			if (P_0 > 0)
			{
				DPmkNFPaorpsAFnSDjTUGPqzfqPeA(P_0);
			}
			aKNDhLcGUfblLhDWqCfmlCZtDtzfb = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
			IPYgDtTmMtXBkVklGxxtIYAxmGqc = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
		}

		public ADictionary(IDictionary<TKey, TValue> P_0)
			: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1)
			: this(P_0, P_1, (IEqualityComparer<TValue>)null)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
			: this(P_0?.Count ?? 0, P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> item in P_0)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			SIyZnALdbiVKJEAhaLvSDLjnWTBE(key, value, true);
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(key, value);
		}

		public void Clear()
		{
			if (_count > 0)
			{
				for (int i = 0; i < aOOsDqWvTQdfaiYnwFDOMasiFYpFA.Length; i++)
				{
					aOOsDqWvTQdfaiYnwFDOMasiFYpFA[i] = -1;
				}
				Array.Clear(_entries, 0, _count);
				dgkLSSnXpcQEwkBHeCZNfJwlJKDn = -1;
				_count = 0;
				hXpSOFEqlPjPNoRtyqrLfhSHEFXEA = 0;
				sdSuPKgRfwizkeBpxcpybNGIECcB++;
				reTgoHUxMqcInLOEwACyilalphpw++;
			}
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		void IDictionary.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOfKey(key) >= 0;
		}

		bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
			return this.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return IndexOfValue(value) >= 0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		public bool Remove(TKey key)
		{
			if (!AwYlkpZPpQBHnIWhEsglUvfGDRgjA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (aOOsDqWvTQdfaiYnwFDOMasiFYpFA != null)
			{
				int num = aKNDhLcGUfblLhDWqCfmlCZtDtzfb.GetHashCode(key) & 0x7FFFFFFF;
				int num2 = num % aOOsDqWvTQdfaiYnwFDOMasiFYpFA.Length;
				int num3 = -1;
				for (int num4 = aOOsDqWvTQdfaiYnwFDOMasiFYpFA[num2]; num4 >= 0; num4 = _entries[num4].next)
				{
					if (_entries[num4].hashCode == num && aKNDhLcGUfblLhDWqCfmlCZtDtzfb.Equals(_entries[num4].key, key))
					{
						if (num3 < 0)
						{
							aOOsDqWvTQdfaiYnwFDOMasiFYpFA[num2] = _entries[num4].next;
						}
						else
						{
							_entries[num3].next = _entries[num4].next;
						}
						_entries[num4].hashCode = -1;
						_entries[num4].next = dgkLSSnXpcQEwkBHeCZNfJwlJKDn;
						_entries[num4].key = default(TKey);
						_entries[num4].value = default(TValue);
						dgkLSSnXpcQEwkBHeCZNfJwlJKDn = num4;
						hXpSOFEqlPjPNoRtyqrLfhSHEFXEA++;
						sdSuPKgRfwizkeBpxcpybNGIECcB++;
						return true;
					}
					num3 = num4;
				}
			}
			return false;
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Remove
			return this.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				value = _entries[num].value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
			return this.TryGetValue(key, out value);
		}

		public TValue GetValueSafe(TKey key)
		{
			int num = IndexOfKey(key);
			if (num >= 0)
			{
				return _entries[num].value;
			}
			return default(TValue);
		}

		public int IndexOfKey(TKey key)
		{
			if (!AwYlkpZPpQBHnIWhEsglUvfGDRgjA && key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (aOOsDqWvTQdfaiYnwFDOMasiFYpFA != null)
			{
				int num = aKNDhLcGUfblLhDWqCfmlCZtDtzfb.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = aOOsDqWvTQdfaiYnwFDOMasiFYpFA[num % aOOsDqWvTQdfaiYnwFDOMasiFYpFA.Length]; num2 >= 0; num2 = _entries[num2].next)
				{
					if (_entries[num2].hashCode == num && aKNDhLcGUfblLhDWqCfmlCZtDtzfb.Equals(_entries[num2].key, key))
					{
						return num2;
					}
				}
			}
			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			Entry[] entries = _entries;
			if (!wXTpjNuOqABCYFtURMJpAYbsqrfv && value == null)
			{
				for (int i = 0; i < _count; i++)
				{
					if (entries[i].hashCode >= 0 && entries[i].value == null)
					{
						return i;
					}
				}
			}
			else
			{
				IEqualityComparer<TValue> iPYgDtTmMtXBkVklGxxtIYAxmGqc = IPYgDtTmMtXBkVklGxxtIYAxmGqc;
				for (int j = 0; j < _count; j++)
				{
					if (entries[j].hashCode >= 0 && iPYgDtTmMtXBkVklGxxtIYAxmGqc.Equals(entries[j].value, value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		public bool IsValidAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			return _entries[index].hashCode >= 0;
		}

		public TKey GetKeyAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return _entries[index].key;
		}

		public TValue GetValueAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return _entries[index].value;
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				throw new ArgumentException("index points to an invalid entry.");
			}
			return new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
		}

		public bool TryGetKeyAt(int index, out TKey key)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				key = default(TKey);
				return false;
			}
			key = _entries[index].key;
			return true;
		}

		public bool TryGetValueAt(int index, out TValue value)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				value = default(TValue);
				return false;
			}
			value = _entries[index].value;
			return true;
		}

		public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
		{
			if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
			return true;
		}

		public bool GetNextIndex(ref int index)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					return true;
				}
				index++;
			}
			return false;
		}

		public int GetNextIndex(int index)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				return -1;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		public bool GetNextKey(ref int index, out TKey key)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				key = default(TKey);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					key = _entries[index].key;
					return true;
				}
				index++;
			}
			key = default(TKey);
			return false;
		}

		public bool GetNextValue(ref int index, out TValue value)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				index++;
			}
			value = default(TValue);
			return false;
		}

		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index++;
			if ((uint)index >= (uint)_count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index < _count)
			{
				if (_entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					return true;
				}
				index++;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetPreviousIndex(ref int index)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					return true;
				}
				index--;
			}
			return false;
		}

		public int GetPreviousIndex(int index)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				return -1;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					return index;
				}
				index--;
			}
			return -1;
		}

		public bool GetPreviousKey(ref int index, out TKey key)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				key = default(TKey);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					key = _entries[index].key;
					return true;
				}
				index--;
			}
			key = default(TKey);
			return false;
		}

		public bool GetPreviousValue(ref int index, out TValue value)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				value = default(TValue);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					value = _entries[index].value;
					return true;
				}
				index--;
			}
			value = default(TValue);
			return false;
		}

		public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			index--;
			if ((uint)index >= (uint)_count)
			{
				entry = default(KeyValuePair<TKey, TValue>);
				return false;
			}
			while (index >= 0)
			{
				if (_entries[index].hashCode >= 0)
				{
					entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
					return true;
				}
				index--;
			}
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool RemoveAt(int index)
		{
			if ((uint)index >= (uint)_count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_entries[index].hashCode < 0)
			{
				return false;
			}
			Remove(_entries[index].key);
			return true;
		}

		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			int count = _count;
			Entry[] entries = _entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array[index++] = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
				}
			}
		}

		private void DPmkNFPaorpsAFnSDjTUGPqzfqPeA(int P_0)
		{
			int num = CsbQggeyBrJfqtXJbQQxhPIBhUXi.XeQYtTGavNxALifQTYSpsecYSwvJ(P_0);
			aOOsDqWvTQdfaiYnwFDOMasiFYpFA = new int[num];
			for (int i = 0; i < aOOsDqWvTQdfaiYnwFDOMasiFYpFA.Length; i++)
			{
				aOOsDqWvTQdfaiYnwFDOMasiFYpFA[i] = -1;
			}
			_entries = new Entry[num];
			dgkLSSnXpcQEwkBHeCZNfJwlJKDn = -1;
		}

		private void SIyZnALdbiVKJEAhaLvSDLjnWTBE(TKey P_0, TValue P_1, bool P_2)
		{
			if (!AwYlkpZPpQBHnIWhEsglUvfGDRgjA && P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			if (aOOsDqWvTQdfaiYnwFDOMasiFYpFA == null)
			{
				DPmkNFPaorpsAFnSDjTUGPqzfqPeA(0);
			}
			int num = aKNDhLcGUfblLhDWqCfmlCZtDtzfb.GetHashCode(P_0) & 0x7FFFFFFF;
			int num2 = num % aOOsDqWvTQdfaiYnwFDOMasiFYpFA.Length;
			for (int num3 = aOOsDqWvTQdfaiYnwFDOMasiFYpFA[num2]; num3 >= 0; num3 = _entries[num3].next)
			{
				if (_entries[num3].hashCode == num && aKNDhLcGUfblLhDWqCfmlCZtDtzfb.Equals(_entries[num3].key, P_0))
				{
					if (P_2)
					{
						throw new ArgumentException("An element with the same key already exists in the dictionary.");
					}
					_entries[num3].value = P_1;
					sdSuPKgRfwizkeBpxcpybNGIECcB++;
					return;
				}
			}
			int count;
			if (hXpSOFEqlPjPNoRtyqrLfhSHEFXEA > 0)
			{
				count = dgkLSSnXpcQEwkBHeCZNfJwlJKDn;
				dgkLSSnXpcQEwkBHeCZNfJwlJKDn = _entries[count].next;
				hXpSOFEqlPjPNoRtyqrLfhSHEFXEA--;
			}
			else
			{
				if (_count == _entries.Length)
				{
					QRexJnLaoRsYKBwrYgdwtRZlAjSL();
					num2 = num % aOOsDqWvTQdfaiYnwFDOMasiFYpFA.Length;
				}
				count = _count;
				_count++;
			}
			_entries[count].hashCode = num;
			_entries[count].next = aOOsDqWvTQdfaiYnwFDOMasiFYpFA[num2];
			_entries[count].key = P_0;
			_entries[count].value = P_1;
			aOOsDqWvTQdfaiYnwFDOMasiFYpFA[num2] = count;
			sdSuPKgRfwizkeBpxcpybNGIECcB++;
			reTgoHUxMqcInLOEwACyilalphpw++;
		}

		private void QRexJnLaoRsYKBwrYgdwtRZlAjSL()
		{
			GfDXGXxFQIkQXGzsrWAZeGtZXqvC(CsbQggeyBrJfqtXJbQQxhPIBhUXi.pMnepxkTtGBACogMgmZMFHxeflbJ(_count), false);
		}

		private void GfDXGXxFQIkQXGzsrWAZeGtZXqvC(int P_0, bool P_1)
		{
			int[] array = new int[P_0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			Entry[] array2 = new Entry[P_0];
			Array.Copy(_entries, 0, array2, 0, _count);
			if (P_1)
			{
				for (int j = 0; j < _count; j++)
				{
					if (array2[j].hashCode != -1)
					{
						array2[j].hashCode = aKNDhLcGUfblLhDWqCfmlCZtDtzfb.GetHashCode(array2[j].key) & 0x7FFFFFFF;
					}
				}
			}
			for (int k = 0; k < _count; k++)
			{
				if (array2[k].hashCode >= 0)
				{
					int num = array2[k].hashCode % P_0;
					array2[k].next = array[num];
					array[num] = k;
				}
			}
			aOOsDqWvTQdfaiYnwFDOMasiFYpFA = array;
			_entries = array2;
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> WCVNPdfFBXBVlYlIxcpekcYuoJUP()
		{
			return new Enumerator(this, 2);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in WCVNPdfFBXBVlYlIxcpekcYuoJUP
			return this.WCVNPdfFBXBVlYlIxcpekcYuoJUP();
		}

		private void OKlJdDEaczhrsnAjagBrpzwnymEi(KeyValuePair<TKey, TValue> P_0)
		{
			Add(P_0.Key, P_0.Value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OKlJdDEaczhrsnAjagBrpzwnymEi
			this.OKlJdDEaczhrsnAjagBrpzwnymEi(P_0);
		}

		private bool OgMhfwDqDhYmEQmKKctKxbkXVCmm(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && IPYgDtTmMtXBkVklGxxtIYAxmGqc.Equals(_entries[num].value, P_0.Value))
			{
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OgMhfwDqDhYmEQmKKctKxbkXVCmm
			return this.OgMhfwDqDhYmEQmKKctKxbkXVCmm(P_0);
		}

		private bool QMTeRfiWZQcmNjPnHjOHrdPsWBAK(KeyValuePair<TKey, TValue> P_0)
		{
			int num = IndexOfKey(P_0.Key);
			if (num >= 0 && IPYgDtTmMtXBkVklGxxtIYAxmGqc.Equals(_entries[num].value, P_0.Value))
			{
				Remove(P_0.Key);
				return true;
			}
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QMTeRfiWZQcmNjPnHjOHrdPsWBAK
			return this.QMTeRfiWZQcmNjPnHjOHrdPsWBAK(P_0);
		}

		private void zSjwqNIGxmvNpjrxRaETukkYDASU(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			CopyTo(P_0, P_1);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zSjwqNIGxmvNpjrxRaETukkYDASU
			this.zSjwqNIGxmvNpjrxRaETukkYDASU(P_0, P_1);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new Exception();
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new Exception();
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < this.Count)
			{
				throw new Exception();
			}
			if (array is KeyValuePair<TKey, TValue>[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (array is DictionaryEntry[])
			{
				DictionaryEntry[] array3 = array as DictionaryEntry[];
				Entry[] entries = _entries;
				for (int i = 0; i < _count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array3[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
					}
				}
				return;
			}
			if (!(array is object[] array4))
			{
				throw new Exception();
			}
			try
			{
				int count = _count;
				Entry[] entries2 = _entries;
				for (int j = 0; j < count; j++)
				{
					if (entries2[j].hashCode >= 0)
					{
						array4[index++] = new KeyValuePair<TKey, TValue>(entries2[j].key, entries2[j].value);
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this, 2);
		}

		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			eMvMVauKSJQvntRixldOITcJzNMG<TValue>(value, "value");
			try
			{
				TKey key2 = (TKey)key;
				try
				{
					Add(key2, (TValue)value);
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
			catch (InvalidCastException)
			{
				throw new Exception();
			}
		}

		bool IDictionary.Contains(object key)
		{
			if (cVGgglEnQkoBMyFDvFtjLDBYCqgcb(key))
			{
				return ContainsKey((TKey)key);
			}
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Enumerator(this, 1);
		}

		void IDictionary.Remove(object key)
		{
			if (cVGgglEnQkoBMyFDvFtjLDBYCqgcb(key))
			{
				Remove((TKey)key);
			}
		}

		private static bool cVGgglEnQkoBMyFDvFtjLDBYCqgcb(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			return P_0 is TKey;
		}

		private static void eMvMVauKSJQvntRixldOITcJzNMG<_0001>(object P_0, string P_1)
		{
			if (P_0 == null && default(_0001) != null)
			{
				throw new ArgumentNullException(P_1);
			}
		}
	}
}

using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.RTEloVsLIxBnlmgnydAWcQJpbcvv, new()
	{
		public interface RTEloVsLIxBnlmgnydAWcQJpbcvv : IComparable<T>
		{
			void DhWbxtCnVdbWhhlTnEwXftzdcZvEc(T P_0);

			bool KvxmGyafWWPVvqJpAvlxzoNLtLLt(T P_0);

			void aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
		}

		public readonly T injector;

		private T[] lYtWVAlqPpkcYbgFfrHTclKBCyyR;

		private int qZdtjcqUeldPdJAIZVnCkitLKRfO;

		private int JSJBBUHbxqZvHmIxTqSDfpnBUquRB;

		private int WZQdALGJjgWaoAlZdrqsDBZcWhmmA;

		private int BxBFXBAuoDhzfwQghYjkGFUhCteXA;

		private bool wAjhxtUVncDTJWkxrPUzqhVceonG;

		public int Count => qZdtjcqUeldPdJAIZVnCkitLKRfO;

		public int Length => qZdtjcqUeldPdJAIZVnCkitLKRfO;

		public int MaxLength => JSJBBUHbxqZvHmIxTqSDfpnBUquRB;

		public int FreeSpace => JSJBBUHbxqZvHmIxTqSDfpnBUquRB - qZdtjcqUeldPdJAIZVnCkitLKRfO;

		public T this[int index]
		{
			get
			{
				if (index >= qZdtjcqUeldPdJAIZVnCkitLKRfO)
				{
					throw new IndexOutOfRangeException();
				}
				return lYtWVAlqPpkcYbgFfrHTclKBCyyR[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			lYtWVAlqPpkcYbgFfrHTclKBCyyR = new T[P_0];
			qZdtjcqUeldPdJAIZVnCkitLKRfO = 0;
			JSJBBUHbxqZvHmIxTqSDfpnBUquRB = P_0;
			wAjhxtUVncDTJWkxrPUzqhVceonG = P_1;
			WZQdALGJjgWaoAlZdrqsDBZcWhmmA = P_2;
			for (int i = 0; i < JSJBBUHbxqZvHmIxTqSDfpnBUquRB; i++)
			{
				lYtWVAlqPpkcYbgFfrHTclKBCyyR[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (wAjhxtUVncDTJWkxrPUzqhVceonG)
			{
				injector.aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (wAjhxtUVncDTJWkxrPUzqhVceonG)
			{
				injector.aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (qZdtjcqUeldPdJAIZVnCkitLKRfO >= JSJBBUHbxqZvHmIxTqSDfpnBUquRB)
			{
				if (WZQdALGJjgWaoAlZdrqsDBZcWhmmA <= 0)
				{
					return -1;
				}
				hbUZMeKzjWZZzpPBLiInJyiVJtMd();
			}
			int num = qZdtjcqUeldPdJAIZVnCkitLKRfO;
			lYtWVAlqPpkcYbgFfrHTclKBCyyR[num].DhWbxtCnVdbWhhlTnEwXftzdcZvEc(item);
			qZdtjcqUeldPdJAIZVnCkitLKRfO = num + 1;
			return num;
		}

		public int AddIfUnique(T item)
		{
			int num = IndexOfData(item);
			if (num >= 0)
			{
				return num;
			}
			return AddData(item);
		}

		public bool ContainsData(T item)
		{
			for (int i = 0; i < qZdtjcqUeldPdJAIZVnCkitLKRfO; i++)
			{
				if (lYtWVAlqPpkcYbgFfrHTclKBCyyR[i].KvxmGyafWWPVvqJpAvlxzoNLtLLt(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < qZdtjcqUeldPdJAIZVnCkitLKRfO; i++)
			{
				if (lYtWVAlqPpkcYbgFfrHTclKBCyyR[i].KvxmGyafWWPVvqJpAvlxzoNLtLLt(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (wAjhxtUVncDTJWkxrPUzqhVceonG)
			{
				injector.aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
				for (int i = 0; i < qZdtjcqUeldPdJAIZVnCkitLKRfO; i++)
				{
					lYtWVAlqPpkcYbgFfrHTclKBCyyR[i].aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
				}
			}
			qZdtjcqUeldPdJAIZVnCkitLKRfO = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= qZdtjcqUeldPdJAIZVnCkitLKRfO)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == qZdtjcqUeldPdJAIZVnCkitLKRfO - 1)
			{
				RemoveLast();
				return;
			}
			if (wAjhxtUVncDTJWkxrPUzqhVceonG)
			{
				lYtWVAlqPpkcYbgFfrHTclKBCyyR[index].aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
			}
			for (int i = index; i < qZdtjcqUeldPdJAIZVnCkitLKRfO - 1; i++)
			{
				lYtWVAlqPpkcYbgFfrHTclKBCyyR[i].DhWbxtCnVdbWhhlTnEwXftzdcZvEc(lYtWVAlqPpkcYbgFfrHTclKBCyyR[i + 1]);
			}
			if (wAjhxtUVncDTJWkxrPUzqhVceonG)
			{
				lYtWVAlqPpkcYbgFfrHTclKBCyyR[qZdtjcqUeldPdJAIZVnCkitLKRfO - 1].aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
			}
			qZdtjcqUeldPdJAIZVnCkitLKRfO--;
		}

		public void RemoveLast()
		{
			if (qZdtjcqUeldPdJAIZVnCkitLKRfO != 0)
			{
				if (wAjhxtUVncDTJWkxrPUzqhVceonG)
				{
					lYtWVAlqPpkcYbgFfrHTclKBCyyR[qZdtjcqUeldPdJAIZVnCkitLKRfO - 1].aEOVnwwqDJMFXPmsMEqAGDVqEgWbb();
				}
				qZdtjcqUeldPdJAIZVnCkitLKRfO--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == JSJBBUHbxqZvHmIxTqSDfpnBUquRB)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, JSJBBUHbxqZvHmIxTqSDfpnBUquRB);
			for (int i = 0; i < num; i++)
			{
				array[i] = lYtWVAlqPpkcYbgFfrHTclKBCyyR[i];
			}
			if (size > JSJBBUHbxqZvHmIxTqSDfpnBUquRB)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (qZdtjcqUeldPdJAIZVnCkitLKRfO > size)
			{
				qZdtjcqUeldPdJAIZVnCkitLKRfO = size;
			}
			JSJBBUHbxqZvHmIxTqSDfpnBUquRB = size;
			lYtWVAlqPpkcYbgFfrHTclKBCyyR = array;
		}

		public void SortAscending()
		{
			if (qZdtjcqUeldPdJAIZVnCkitLKRfO == 0)
			{
				return;
			}
			for (int i = 0; i < qZdtjcqUeldPdJAIZVnCkitLKRfO - 1; i++)
			{
				for (int j = i + 1; j < qZdtjcqUeldPdJAIZVnCkitLKRfO; j++)
				{
					if (lYtWVAlqPpkcYbgFfrHTclKBCyyR[j].CompareTo(lYtWVAlqPpkcYbgFfrHTclKBCyyR[i]) < 0)
					{
						T val = lYtWVAlqPpkcYbgFfrHTclKBCyyR[i];
						lYtWVAlqPpkcYbgFfrHTclKBCyyR[i] = lYtWVAlqPpkcYbgFfrHTclKBCyyR[j];
						lYtWVAlqPpkcYbgFfrHTclKBCyyR[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (qZdtjcqUeldPdJAIZVnCkitLKRfO == 0)
			{
				return;
			}
			for (int i = 0; i < qZdtjcqUeldPdJAIZVnCkitLKRfO - 1; i++)
			{
				for (int j = i + 1; j < qZdtjcqUeldPdJAIZVnCkitLKRfO; j++)
				{
					if (lYtWVAlqPpkcYbgFfrHTclKBCyyR[j].CompareTo(lYtWVAlqPpkcYbgFfrHTclKBCyyR[i]) > 0)
					{
						T val = lYtWVAlqPpkcYbgFfrHTclKBCyyR[i];
						lYtWVAlqPpkcYbgFfrHTclKBCyyR[i] = lYtWVAlqPpkcYbgFfrHTclKBCyyR[j];
						lYtWVAlqPpkcYbgFfrHTclKBCyyR[j] = val;
					}
				}
			}
		}

		private void hbUZMeKzjWZZzpPBLiInJyiVJtMd()
		{
			BxBFXBAuoDhzfwQghYjkGFUhCteXA++;
			Resize(JSJBBUHbxqZvHmIxTqSDfpnBUquRB + BxBFXBAuoDhzfwQghYjkGFUhCteXA * WZQdALGJjgWaoAlZdrqsDBZcWhmmA);
		}
	}
}

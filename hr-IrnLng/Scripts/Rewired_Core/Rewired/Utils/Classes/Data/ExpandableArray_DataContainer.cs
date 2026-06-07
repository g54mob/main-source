using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.pqSaXXckQhKEYznYQYBpSAuUXxa, new()
	{
		public interface pqSaXXckQhKEYznYQYBpSAuUXxa : IComparable<T>
		{
			void NGXUBbcPdrBYfEJQGstImmQAGjsO(T P_0);

			bool HSdDwaaSirDaxBQdgRrBRcKQYko(T P_0);

			void VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}

		public readonly T injector;

		private T[] NjLrcxmsMFKBjPvxolrqYGyaxxm;

		private int CDzbpRJQpGdOuLGtomnQLsBZocNx;

		private int ArOAGxDbCBVaKmShSGyUFllDxFvl;

		private int OvkWFFsSlufkGfFEWDGrFUxalwL;

		private int oEJJHZuzfbMhYBSZMtiHgMEEuwt;

		private bool pNwnozCTzckLwmiZsyhMJZvlkWo;

		public int Count => CDzbpRJQpGdOuLGtomnQLsBZocNx;

		public int Length => CDzbpRJQpGdOuLGtomnQLsBZocNx;

		public int MaxLength => ArOAGxDbCBVaKmShSGyUFllDxFvl;

		public int FreeSpace => ArOAGxDbCBVaKmShSGyUFllDxFvl - CDzbpRJQpGdOuLGtomnQLsBZocNx;

		public T this[int index]
		{
			get
			{
				if (index >= CDzbpRJQpGdOuLGtomnQLsBZocNx)
				{
					throw new IndexOutOfRangeException();
				}
				return NjLrcxmsMFKBjPvxolrqYGyaxxm[index];
			}
		}

		public ExpandableArray_DataContainer(int startingMaxLength, bool clearData = true, int expansionIncrement = 0)
		{
			injector = new T();
			NjLrcxmsMFKBjPvxolrqYGyaxxm = new T[startingMaxLength];
			CDzbpRJQpGdOuLGtomnQLsBZocNx = 0;
			ArOAGxDbCBVaKmShSGyUFllDxFvl = startingMaxLength;
			pNwnozCTzckLwmiZsyhMJZvlkWo = clearData;
			OvkWFFsSlufkGfFEWDGrFUxalwL = expansionIncrement;
			for (int i = 0; i < ArOAGxDbCBVaKmShSGyUFllDxFvl; i++)
			{
				NjLrcxmsMFKBjPvxolrqYGyaxxm[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (pNwnozCTzckLwmiZsyhMJZvlkWo)
			{
				T val = injector;
				val.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (pNwnozCTzckLwmiZsyhMJZvlkWo)
			{
				T val = injector;
				val.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (CDzbpRJQpGdOuLGtomnQLsBZocNx >= ArOAGxDbCBVaKmShSGyUFllDxFvl)
			{
				if (OvkWFFsSlufkGfFEWDGrFUxalwL <= 0)
				{
					return -1;
				}
				yFCrdaQqchkDbOHkpQKsxrPhKOU();
			}
			int cDzbpRJQpGdOuLGtomnQLsBZocNx = CDzbpRJQpGdOuLGtomnQLsBZocNx;
			NjLrcxmsMFKBjPvxolrqYGyaxxm[cDzbpRJQpGdOuLGtomnQLsBZocNx].NGXUBbcPdrBYfEJQGstImmQAGjsO(item);
			CDzbpRJQpGdOuLGtomnQLsBZocNx = cDzbpRJQpGdOuLGtomnQLsBZocNx + 1;
			return cDzbpRJQpGdOuLGtomnQLsBZocNx;
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
			for (int i = 0; i < CDzbpRJQpGdOuLGtomnQLsBZocNx; i++)
			{
				if (NjLrcxmsMFKBjPvxolrqYGyaxxm[i].HSdDwaaSirDaxBQdgRrBRcKQYko(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < CDzbpRJQpGdOuLGtomnQLsBZocNx; i++)
			{
				if (NjLrcxmsMFKBjPvxolrqYGyaxxm[i].HSdDwaaSirDaxBQdgRrBRcKQYko(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (pNwnozCTzckLwmiZsyhMJZvlkWo)
			{
				T val = injector;
				val.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				for (int i = 0; i < CDzbpRJQpGdOuLGtomnQLsBZocNx; i++)
				{
					NjLrcxmsMFKBjPvxolrqYGyaxxm[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
			}
			CDzbpRJQpGdOuLGtomnQLsBZocNx = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= CDzbpRJQpGdOuLGtomnQLsBZocNx)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == CDzbpRJQpGdOuLGtomnQLsBZocNx - 1)
			{
				RemoveLast();
				return;
			}
			if (pNwnozCTzckLwmiZsyhMJZvlkWo)
			{
				NjLrcxmsMFKBjPvxolrqYGyaxxm[index].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			for (int i = index; i < CDzbpRJQpGdOuLGtomnQLsBZocNx - 1; i++)
			{
				ref readonly T reference = ref NjLrcxmsMFKBjPvxolrqYGyaxxm[i];
				T val = NjLrcxmsMFKBjPvxolrqYGyaxxm[i + 1];
				reference.NGXUBbcPdrBYfEJQGstImmQAGjsO(val);
			}
			if (pNwnozCTzckLwmiZsyhMJZvlkWo)
			{
				NjLrcxmsMFKBjPvxolrqYGyaxxm[CDzbpRJQpGdOuLGtomnQLsBZocNx - 1].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			CDzbpRJQpGdOuLGtomnQLsBZocNx--;
		}

		public void RemoveLast()
		{
			if (CDzbpRJQpGdOuLGtomnQLsBZocNx != 0)
			{
				if (pNwnozCTzckLwmiZsyhMJZvlkWo)
				{
					NjLrcxmsMFKBjPvxolrqYGyaxxm[CDzbpRJQpGdOuLGtomnQLsBZocNx - 1].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
				CDzbpRJQpGdOuLGtomnQLsBZocNx--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == ArOAGxDbCBVaKmShSGyUFllDxFvl)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, ArOAGxDbCBVaKmShSGyUFllDxFvl);
			for (int i = 0; i < num; i++)
			{
				array[i] = NjLrcxmsMFKBjPvxolrqYGyaxxm[i];
			}
			if (size > ArOAGxDbCBVaKmShSGyUFllDxFvl)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (CDzbpRJQpGdOuLGtomnQLsBZocNx > size)
			{
				CDzbpRJQpGdOuLGtomnQLsBZocNx = size;
			}
			ArOAGxDbCBVaKmShSGyUFllDxFvl = size;
			NjLrcxmsMFKBjPvxolrqYGyaxxm = array;
		}

		public void SortAscending()
		{
			if (CDzbpRJQpGdOuLGtomnQLsBZocNx == 0)
			{
				return;
			}
			for (int i = 0; i < CDzbpRJQpGdOuLGtomnQLsBZocNx - 1; i++)
			{
				for (int j = i + 1; j < CDzbpRJQpGdOuLGtomnQLsBZocNx; j++)
				{
					ref readonly T reference = ref NjLrcxmsMFKBjPvxolrqYGyaxxm[j];
					T other = NjLrcxmsMFKBjPvxolrqYGyaxxm[i];
					if (reference.CompareTo(other) < 0)
					{
						T val = NjLrcxmsMFKBjPvxolrqYGyaxxm[i];
						NjLrcxmsMFKBjPvxolrqYGyaxxm[i] = NjLrcxmsMFKBjPvxolrqYGyaxxm[j];
						NjLrcxmsMFKBjPvxolrqYGyaxxm[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (CDzbpRJQpGdOuLGtomnQLsBZocNx == 0)
			{
				return;
			}
			for (int i = 0; i < CDzbpRJQpGdOuLGtomnQLsBZocNx - 1; i++)
			{
				for (int j = i + 1; j < CDzbpRJQpGdOuLGtomnQLsBZocNx; j++)
				{
					ref readonly T reference = ref NjLrcxmsMFKBjPvxolrqYGyaxxm[j];
					T other = NjLrcxmsMFKBjPvxolrqYGyaxxm[i];
					if (reference.CompareTo(other) > 0)
					{
						T val = NjLrcxmsMFKBjPvxolrqYGyaxxm[i];
						NjLrcxmsMFKBjPvxolrqYGyaxxm[i] = NjLrcxmsMFKBjPvxolrqYGyaxxm[j];
						NjLrcxmsMFKBjPvxolrqYGyaxxm[j] = val;
					}
				}
			}
		}

		private void yFCrdaQqchkDbOHkpQKsxrPhKOU()
		{
			oEJJHZuzfbMhYBSZMtiHgMEEuwt++;
			Resize(ArOAGxDbCBVaKmShSGyUFllDxFvl + oEJJHZuzfbMhYBSZMtiHgMEEuwt * OvkWFFsSlufkGfFEWDGrFUxalwL);
		}
	}
}

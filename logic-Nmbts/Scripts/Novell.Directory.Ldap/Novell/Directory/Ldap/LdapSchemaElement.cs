using System;
using System.Collections;
using Novell.Directory.Ldap.Utilclass;

namespace Novell.Directory.Ldap
{
	public abstract class LdapSchemaElement : LdapAttribute
	{
		[CLSCompliant(false)]
		protected internal string[] names = new string[1] { "" };

		protected internal string oid = "";

		[CLSCompliant(false)]
		protected internal string description = "";

		[CLSCompliant(false)]
		protected internal bool obsolete;

		protected internal string[] qualifier = new string[1] { "" };

		protected internal Hashtable hashQualifier;

		public virtual string[] Names
		{
			get
			{
				if (names == null)
				{
					return null;
				}
				string[] array = new string[names.Length];
				names.CopyTo(array, 0);
				return array;
			}
		}

		public virtual string Description
		{
			get
			{
				return description;
			}
		}

		public virtual string ID
		{
			get
			{
				return oid;
			}
		}

		public virtual IEnumerator QualifierNames
		{
			get
			{
				return new EnumeratedIterator(new SupportClass.SetSupport(hashQualifier.Keys).GetEnumerator());
			}
		}

		public virtual bool Obsolete
		{
			get
			{
				return obsolete;
			}
		}

		private void InitBlock()
		{
			hashQualifier = new Hashtable();
		}

		protected internal LdapSchemaElement(string attrName)
			: base(attrName)
		{
			InitBlock();
		}

		public virtual string[] getQualifier(string name)
		{
			AttributeQualifier attributeQualifier = (AttributeQualifier)hashQualifier[name];
			if (attributeQualifier != null)
			{
				return attributeQualifier.Values;
			}
			return null;
		}

		public override string ToString()
		{
			return formatString();
		}

		protected internal abstract string formatString();

		public virtual void setQualifier(string name, string[] values)
		{
			AttributeQualifier newValue = new AttributeQualifier(name, values);
			SupportClass.PutElement(hashQualifier, name, newValue);
			base.Value = formatString();
		}

		public override void addValue(string value_Renamed)
		{
			throw new NotSupportedException("addValue is not supported by LdapSchemaElement");
		}

		public virtual void addValue(byte[] value_Renamed)
		{
			throw new NotSupportedException("addValue is not supported by LdapSchemaElement");
		}

		public override void removeValue(string value_Renamed)
		{
			throw new NotSupportedException("removeValue is not supported by LdapSchemaElement");
		}

		public virtual void removeValue(byte[] value_Renamed)
		{
			throw new NotSupportedException("removeValue is not supported by LdapSchemaElement");
		}
	}
}

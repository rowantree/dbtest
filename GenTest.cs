using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbtest
{
	class GenTest<T, S>
	{
		private T m_value;
		private S m_valueS;

		public GenTest(T value, S valueS)
		{
			m_value = value;
			m_valueS = valueS;
		}

		public T Value
		{
			get
			{
				return m_value;
			}
		}

		public S ValueS
		{
			get
			{
				return m_valueS;
			}
		}
	}

	class TestIt
	{
		public void Run()
		{
			GenTest<int, bool> genTest = new GenTest<int, bool>(34, false);
		}
	}
}

using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

	/*[UnityTest]
	public IEnumerator MonoBehaviourTest_Works()
	{
		yield return new MonoBehaviourTest<MyMonoBehaviourTest>();
	}*/
	
	public class MyMonoBehaviourTest : MonoBehaviour/*, IMonoBehaviourTest*/
	{
		DBQueryScript v=new DBQueryScript();       

        //[TestMethod]
		[Test]
        public void TestMethod1()
        {	string expectedStrings="";
			for (int i=0;i<16;i++){
				string expectedString= "name = " + "Learning Java" + "  author = " + "Jonattan Knuttsen" + "  year = " + 2000 + " publisher = " + "Pearson" + " category = "+ "programming";
				expectedStrings+= expectedString+"\n";
			}
            string resultString = v.selectwhere("programming");

            Assert.AreEqual(expectedStrings, resultString);
        }
        //[TestMethod]
		[Test]
        public void TestMethod2()
        {	string expectedStrings="";
			for (int i=0;i<13;i++){
				string expectedString = "name = " + "Clean Code" + "  author = " + "Robert Martin" + "  year = " + 2001 + " publisher = " + "Pearson" + " category = " + "software engineering";
				expectedStrings+= expectedString+"\n";
			}
            string resultString = v.selectwhere("software engineering");

            Assert.AreEqual(expectedStrings, resultString);
        }
		//[TestMethod]
        [Test]
		public void TestMethod3()
        {
            int expectedsize=29;
            int resultsize = v.getSize();

            Assert.AreEqual(expectedsize, resultsize);
        }
	}
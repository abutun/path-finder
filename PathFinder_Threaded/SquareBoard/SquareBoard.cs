/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PathFinder
{
    public class SquareBoard
    {
        private Square[,] innerList;

        public SquareBoard(int capacity)
        {
            this.innerList = new Square[capacity, capacity];

            Init(capacity);
        }

        private void Init(int capacity)
        {
            for(int i=0;i<capacity;i++)
                for(int j=0;j<capacity;j++)
                    this.innerList[i,j] = new Square(i,j);
        }

        #region IList<Square> Members

        public int IndexOf(Square item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Insert(int i, int j, Square item)
        {
            this.innerList[i, j] = item;
        }

        public void RemoveAt(int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Square this[int i, int j]
        {
            get
            {
                return this.innerList[i, j];
            }
            set
            {
                this.innerList[i, j] = value;
            }
        }

        #endregion

        #region ICollection<Square> Members

        public void Add(Square item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Clear()
        {
            //
        }

        public bool Contains(Square item)
        {
            return false;
        }

        public void CopyTo(Square[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { return this.innerList.Length; }
        }

        public bool IsReadOnly
        {
            get { return this.innerList.IsReadOnly; }
        }

        public bool Remove(Square item)
        {
            return false;
        }

        #endregion

        #region IEnumerable<Square> Members

        public IEnumerator<Square> GetEnumerator()
        {
            return (IEnumerator<Square>)this.innerList.GetEnumerator();
        }

        #endregion
    }
}

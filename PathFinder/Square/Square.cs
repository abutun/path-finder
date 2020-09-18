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
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PathFinder
{
    public class Square
    {
        private int innerX_;
        private int innerY_;

        private SquareStatus innerStatus_ = SquareStatus.EMPTY;
        private SquareType innerType_ = SquareType.SQUARE;
        private SquarePathStatus innerPathStatus_ = SquarePathStatus.NONE;

        private PathManagerCollection ownerPathManagers_ = new PathManagerCollection();

        public Square(int x, int y)
        {
            this.innerX_ = x;
            this.innerY_ = y;
        }

        public int X
        {
            get
            {
                return innerX_;
            }
            set
            {
                this.innerX_ = value;
            }
        }

        public int Y
        {
            get
            {
                return innerY_;
            }
            set
            {
                this.innerY_ = value;
            }
        }

        public SquareStatus Status
        {
            get
            {
                return this.innerStatus_;
            }
            set
            {
                this.innerStatus_ = value;
            }
        }

        public SquarePathStatus PathStatus
        {
            get
            {
                return this.innerPathStatus_;
            }
            set
            {
                this.innerPathStatus_ = value;
            }
        }

        public SquareType Type
        {
            get
            {
                return this.innerType_;
            }
            set
            {
                this.innerType_ = value;

                if (value == SquareType.WALL || value == SquareType.BORDER)
                    this.PathStatus = SquarePathStatus.NONE;
            }
        }

        public Color TypeColor
        {
            get
            {
                switch (this.innerType_)
                {
                    case SquareType.BORDER: return Color.Yellow;

                    case SquareType.SQUARE: return Color.LightGray;

                    case SquareType.WALL: return Color.DarkGray;

                    default: return Color.Orange; // unknown

                }
            }
        }

        public Color PathStatusColor
        {
            get
            {
                if (this.innerType_ == SquareType.SQUARE)
                {
                    switch (this.innerPathStatus_)
                    {
                        case SquarePathStatus.CORRECT: return Color.LightBlue;

                        case SquarePathStatus.WRONG: return Color.Red;

                        case SquarePathStatus.PATH: return Color.Orange;

                        case SquarePathStatus.NONE: return Color.LightGray;

                        default: return Color.Blue; // unknown

                    }
                }
                else
                    return this.TypeColor;
            }
        }

        public PathManagerCollection Owners
        {
            get
            {
                return this.ownerPathManagers_;
            }
        }

        public void ResetSquare()
        {
            // set type to square
            this.innerType_ = SquareType.SQUARE;

            // set square to empty
            this.innerStatus_ = SquareStatus.EMPTY;
            
            // no path information
            this.innerPathStatus_ = SquarePathStatus.NONE;

            // also no owners
            this.Owners.Clear();
        }
    }
}

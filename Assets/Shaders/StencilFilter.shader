Shader "Custom/StencilFilter"
{
    Properties
    {
       _Color ("Color", Color) = (1,1,1,1) //default value
       [Enum(Equal, 3, NotEqual, 6)] _StencilTest ("Stencil Test", int) = 6 //3 & 6 in Enum is indx nu in compare function accrodign to documentation
    }
    SubShader
    {
        
        Color [_Color]
        Stencil{
            Ref 1
            Comp [_StencilTest]
        }

        Pass
        {
            
        }
    }
}

//What basically we are doing is! using CF Equal and NotEqual with Stencil to decide Do we need to perticular portaion of object or not!
//If we set Stencil Test to equal then it will render only inside portion and vice-versa
// REFER - https://docs.unity3d.com/Manual/SL-Stencil.html
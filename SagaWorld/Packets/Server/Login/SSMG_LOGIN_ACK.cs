using System;
using System.Collections.Generic;
using System.Text;

using SagaLib;

namespace SagaWorld.Packets.Server
{
    public class SSMG_LOGIN_ACK : Packet
    {
        /*
         * result 
           00000000: 傖髡 
           fffffffe: GAME_SMSG_LOGIN_ERR_UNKNOWN_ACC,"ID引凶反由旦��E`玉互綃中引允" 
           fffffffd: GAME_SMSG_LOGIN_ERR_BADPASS,"ID引凶反由旦��E`玉互綃中引允" 
           fffffffc: GAME_SMSG_LOGIN_ERR_BFALOCK,"仇及失市它�?�反庲偩�C夔互伕永弁今��E々中牏�" 
           fffffffb: GAME_SMSG_LOGIN_ERR_ALREADY,"暫卞伕弘奶�?楔々中牏�$r政婓及伕弘奶�?��B�?�E誑疇�中凶仄引允" 
           fffffffa: GAME_SMSG_LOGIN_ERR_IPBLOCK,"政婓丟�?ぁ吤?墅苳リ�" 
           fffffff5: GAME_SMSG_GHLOGIN_ERR_101,"必奈丞蹋�?疥��B中井﹜燠溼ぶ嶲з��Eリ飽�$r��Eg腎嶕及源反�?宒腎嶕�?��g引六仁分今中﹝" 
           fffffff4: GAME_SMSG_GHLOGIN_ERR_102,"庲偩今��E々中吨丑═牏縣狨貔襖�砦今��E澠D 匹允﹝" 
           fffffff3: GAME_SMSG_GHLOGIN_ERR_103,"庲偩今��E々中吨丑═牏縣狨貔襖�砦今��E澠D 匹允﹝" 
           fffffff2: GAME_SMSG_GHLOGIN_ERR_104,"庲偩今��E々中吨丑═牏縣狨貔襖�砦今��E澠D 匹允﹝" 
           fffffff1: GAME_SMSG_GHLOGIN_ERR_105,"ECO反�?宒扔奈申旦午卅曰引仄凶﹝$r布�?菮`及失玄仿弁扑亦�?誑?罹`匹﹜失玄仿弁扑亦�?D及憂葆仃�I燴�?軋�中仄引允﹝" 
           fffffff0: GAME_SMSG_GHLOGIN_ERR_106,"汕扔奈申旦反皺賸仄引仄凶﹝�?宒扔奈申旦嶱宎引匹云�?切仁分今中﹝" 
           ffffffef: GAME_SMSG_GHLOGIN_ERR_107,"云��E滑粨g反皺賸仄引仄凶﹝$r蜊戶化失玄仿弁扑亦�?誑?罹`匹ID及�?氻?軋�中仄引允﹝" 
           ffffffee: AME_SMSG_GHLOGIN_ERR_108,"仍��E忖竣�E縑舅肴�E弒D★反弁伕奈朮玉矛奈正氾旦玄及隅�E�?﹜$r珂覂20,000鏝{�及腎嶕皺賸摽卞逃俴今��E澠D匹允﹝$r謁��E�E磥牏馱活═椅�E忖竣�E縑舅肴�E弒D★反公及引引�?痐楔々中縣壑迭�$r棒隙�g囥軑隅及矛奈正氾旦玄�?玫?切仁分今中﹝$rㄗ棒隙�g囥軑隅及矛奈正氾旦玄反ECO鼠宒扔奶玄匹仍偶囀中凶仄引允﹝ㄘ" 
           ffffffed: GAME_SMSG_GHLOGIN_ERR_109,"庲偩軑�銗言撽`109" 
           ffffffec: GAME_SMSG_GHLOGIN_ERR_110,"庲偩軑�銗言撽`110" 
           公��E奜�E GAME_SMSG_LOGIN_ERR_ERR,"祥�?吤言撽`(%d)" 
        */
        public enum Result
        {
            OK = 0,
            GAME_SMSG_LOGIN_ERR_UNKNOWN_ACC = -2,
            GAME_SMSG_LOGIN_ERR_BADPASS = -3,
            GAME_SMSG_LOGIN_ERR_BFALOCK = -4,
            GAME_SMSG_LOGIN_ERR_ALREADY = -5,
            GAME_SMSG_LOGIN_ERR_IPBLOCK = -6
        }
        public SSMG_LOGIN_ACK()
        {
            this.data = new byte[18];
            this.offset = 14;
            this.ID = 0x20;            
        }

        public Result LoginResult
        {
            set
            {
                this.PutUInt((uint)value, 2);
            }
        }

        public uint AccountID
        {
            set
            {
                this.PutUInt(value, 6);
            }
        }

        /// <summary>
        /// 必旦玄ID紹曰�r嶲         
        /// </summary>
        public uint RestTestTime
        {
            set
            {
                this.PutUInt(value, 10);
            }
        }
        
        /// <summary>
        /// 必旦玄IDぶ癹﹛(1970��E堎1��0�r0煦0��E咫擗恞�E?ㄘ08/01/11方��E
        /// End time of trial(second count since 1st Jan. 1970)
        /// </summary>
        public uint TestEndTime
        {
            set
            {
                this.PutUInt(value, 14);
            }
        }

    }
}


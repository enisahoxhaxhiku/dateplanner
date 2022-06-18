import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
//import {NavLink} from 'react-router-dom';
import {Helmet} from "react-helmet";
import { Button , ButtonToolbar} from 'react-bootstrap';
import AddLokacioni from './AddLokacioni';
import { EditLokacioni } from './EditLokacioni';
                           //./EditPerdorues
                         

export class Lokacioni extends Component{
    constructor(props){
        super(props)
        this.state={l:[], addModalShow:false, editModalShow:false, DataisLoaded: false}
    } 

   refreshList(){
    fetch(
        "https://localhost:7003/api/Lokacioni")
                    .then((res) => res.json())
                    .then((json) => {
                        this.setState({
                            l: json,
                            DataisLoaded: true
                        });
                    })
    }
    
    componentDidMount(){
      this.refreshList();      
   }

    componentDidUpdate(){
        this.refreshList();
    }
    
    deletel(lID){
        if(window.confirm('Jeni i sigurt qe doni ta fshini Lokacionin?')){
            fetch(process.env.REACT_APP_API+'Lokacioni/'+lID,{
                method:'DELETE',
                header:{
                    'Accept':'application/json',
                    'Content-Type':'application/json'
                }
            })
        }
    }
    
    render(){
        const {l, ak, ll, lID}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div className="container">
                <Helmet>
                <title>Lokacioni</title>
                </Helmet>
               

                <ButtonToolbar>
                    <Button className="mt-4" variant="primary" onClick={()=>this.setState({addModalShow:true})}>
                       Shto Lokacionin
                    </Button>

                    <AddLokacioni show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                        <th>Aktivitetet</th>
                        <th>LlojiLokacionit</th>
                    
                      
                        </tr>
                    </thead>
                    <tbody>
                        {l.map(l=>
                            <tr key={l.LokacioniID}>
                                <td>{l.Aktivitetet}</td>
                                <td>{l.LlojiLokacionit}</td>
                                
                                <td>
                               <ButtonToolbar>
                                   <Button className="mr-2" variant="info" onClick={()=>this.setState({editModalShow:true, lID:l.LokacioniID,
                                ak:l.Aktivitetet,ll:l.LlojiLokacionit})}>
                                       Edit
                                   </Button>

                                   <Button className="mr-2" variant="danger" onClick={()=>this.deletel(l.LokacioniID)}>
                                       Delete
                                   </Button>

                                   <EditLokacioni show={this.state.editModalShow} onHide={editModalClose}
                                   lID={lID}
                                   ak={ak}
                                   ll={ll}/>
                                   
                               </ButtonToolbar>

                                </td>
                            </tr>)}
                    </tbody>

                </Table>
            </div>
        )
    }
}
import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';


export class EditLokacioni extends Component{
    constructor(props){
        super(props);
        this.submitLokacionil=this.submitLokacionil.bind(this);
    }

    submitLokacionil(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'Lokacioni',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                LokacioniLID:event.target.LokacioniLID.value,
                Aktivitetet:event.target.Aktivitetet.value,
                LlojiLokacionit:event.target.LlojiLokacionit.value
              
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('An error occurred.');
        })
    }
    render(){
        return(
            <div className="container">
                <Modal {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter" centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Update Lokacionin
                        </Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.submitLokacionil}>
                                <Form.Group controlId="LokacioniLID">
                                        <Form.Control type="text" name="LokacioniL" required hidden defaultValue={this.props.aktid} placeholder="LokacioniLID" />
                                    </Form.Group>
                                    <Form.Group controlId="Aktivitetet">
                                        <Form.Label>Aktivitetet</Form.Label>
                                        <Form.Control type="text" name="Aktivitetet" required defaultValue={this.props.emri} placeholder="Aktivitetet" />
                                    </Form.Group>
                                    <Form.Group controlId="LlojiLokacionit">
                                        <Form.Label>LlojiLokacionit</Form.Label>
                                        <Form.Control type="text" name="LlojiLokacionit" required defaultValue={this.props.mbi} placeholder="LlojiLokacionit" />
                                    </Form.Group>
                                

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Update Lokacionin
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
}
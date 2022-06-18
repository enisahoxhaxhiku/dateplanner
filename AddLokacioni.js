import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';
import * as Yup from 'yup';
import { Formik, Field, ErrorMessage } from 'formik';


export default class AddLokacioni extends Component{
    constructor(props){
        super(props);
        this.submitLokacionil=this.submitLokacionil.bind(this);
    }

     //Validimi
    validationSchema() {
        return Yup.object().shape({
          Aktivitetet: Yup.string()
            .required('Aktivitetet must be filled in.')
            .matches(
                /^[A-Za-z .]{3,15}$/,
                "Aktivitetet should contain only Letters and be longer than 2 letters and not longer than 15 letters."
              ),
            LlojiLokacionit: Yup.string()
            .required('LlojiLokacionit must be filled in')
            .matches(
                /^[A-Za-z .]{4,15}$/,
                "LlojiLokacionit should contain only Letters and be longer than 3 letters and not longer than 15 letters."
              ),
            
        });
      }
      //
    submitLokacionil(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'Lokacioni',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
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
        const initialValues = {
            Aktivitetet: '',
            LlojiLokacionit: '',
          
          };
        return(
            <div className="container">
                <Modal {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter" centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Shto Lokacionin
                        </Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                            <Formik
                               initialValues={initialValues}
                               validationSchema={this.validationSchema}
                               onSubmit={this.submitLokacionil}
                             >
                                 {({ submitLokacionil, isValid, isSubmitting, dirty }) => (
                                <Form onSubmit={this.submitLokacionil}>
                                    <Form.Group controlId="Aktivitetet">
                                        <Form.Label>Aktivitetet</Form.Label>
                                        <Field type="text" name="Aktivitetet" required placeholder="Aktivitetet" className="form-control" />
                                        <ErrorMessage
                                          name="Aktivitetet"
                                          component="div"
                                          className="text-danger"
                                         />
                                    </Form.Group>
                                    <Form.Group controlId="LlojiLokacionit">
                                        <Form.Label>LlojiLokacionit</Form.Label>
                                        <Field type="text" name="LlojiLokacionit" required placeholder="LlojiLokacionit" className="form-control" />
                                        <ErrorMessage
                                         name="LlojiLokacionit"
                                         component="div"
                                         className="text-danger"
                                        />
                                    </Form.Group>
                                    
                                    <Form.Group>
                                        <Button disabled={isSubmitting || !dirty || !isValid}  variant="primary" type="submit">
                                            Shto Lokacionin
                                        </Button>
                                    </Form.Group>
                                </Form>
                                   )}
                                </Formik>
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